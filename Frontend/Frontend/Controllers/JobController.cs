using System.Net.Http.Headers;
using System.Security.Claims;
using JobEntry.DTO.ApplyJobDTOs;
using JobEntry.DTO.JobDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

public class JobController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public JobController( IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 10;

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5214/api/Job/GetAllJob");    

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var allJobs = JsonConvert.DeserializeObject<List<ResultGetAllJobDto>>(jsonData);

            // Sayfalama
            var pagedJobs = allJobs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(allJobs.Count / (double)pageSize);

            return View(pagedJobs);
        }

        return View(new List<ResultGetAllJobDto>());    
    }

    public async Task<IActionResult> JobDetail(string id)
    {
        ViewBag.jobid = id;
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5214/api/Job/with-property/"+id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultGetAllJobDto>(jsonData);
            return View(values);
        }
        return View();
    }


    
    [HttpGet]
    public PartialViewResult ApplyJob()
    {
        
        return PartialView();
    }
    
    
    [HttpPost]
public async Task<IActionResult> ApplyJob([FromForm] CreeteApplyJobDto creeteApplyJobDto)
{
    // Başvuru zamanı
    creeteApplyJobDto.AppliedAt = DateTime.Now;

    // Giriş yapan kullanıcının ID'sini al
    var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
    creeteApplyJobDto.AppUserId = userId;

    var client = _httpClientFactory.CreateClient();
    using var content = new MultipartFormDataContent();

    // String alanları ekle
    content.Add(new StringContent(creeteApplyJobDto.NameSurname), "NameSurname");
    content.Add(new StringContent(creeteApplyJobDto.Email), "Email");
    content.Add(new StringContent(creeteApplyJobDto.Website ?? ""), "Website");
    content.Add(new StringContent(creeteApplyJobDto.AppliedAt.ToString("o")), "AppliedAt");
    content.Add(new StringContent(creeteApplyJobDto.JobId), "JobId");

    // Giriş yapılmışsa AppUserId'yi gönder
    if (!string.IsNullOrEmpty(creeteApplyJobDto.AppUserId))
    {
        content.Add(new StringContent(creeteApplyJobDto.AppUserId), "AppUserId");
    }

    // CV dosyası varsa ekle
    if (creeteApplyJobDto.CvFile != null && creeteApplyJobDto.CvFile.Length > 0)
    {
        var fileStream = creeteApplyJobDto.CvFile.OpenReadStream();
        var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(creeteApplyJobDto.CvFile.ContentType);
        content.Add(fileContent, "CvFile", creeteApplyJobDto.CvFile.FileName);
    }

    // API'ye gönder
    var response = await client.PostAsync("http://localhost:5214/api/ApplyJob", content);

    if (response.IsSuccessStatusCode)
    {
        TempData["SuccessMessage"] = "Başvurunuz başarıyla gönderildi.";
        return RedirectToAction("JobDetail", new { id = creeteApplyJobDto.JobId });
    }

    // Hata varsa detaylı oku
    var responseContent = await response.Content.ReadAsStringAsync();
    var problemDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent);
    var allErrors = problemDetails?.Errors?.SelectMany(e => e.Value).ToList() ?? new List<string> { "Bilinmeyen bir hata oluştu." };
    TempData["ErrorMessages"] = JsonConvert.SerializeObject(allErrors);

    return RedirectToAction("JobDetail", new { id = creeteApplyJobDto.JobId });
}



}