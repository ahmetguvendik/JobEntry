using System.Net.Http.Headers;
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
        var response = await client.GetAsync("http://localhost:5202/api/Job/GetAllJob");    

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
        var response = await client.GetAsync($"http://localhost:5202/api/Job/with-property/"+id);
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

    public async Task<IActionResult> ApplyJob(CreeteApplyJobDto creeteApplyJobDto)
    {
        creeteApplyJobDto.AppliedAt = DateTime.Now;
        var client = _httpClientFactory.CreateClient();
        using var content = new MultipartFormDataContent();

        if (creeteApplyJobDto.CvFile != null && creeteApplyJobDto.CvFile.Length > 0)
        {
            var fileStream = creeteApplyJobDto.CvFile.OpenReadStream();
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(creeteApplyJobDto.CvFile.ContentType);
            content.Add(fileContent, "CvFile", creeteApplyJobDto.CvFile.FileName);
        }

        var response = await client.PostAsync($"http://localhost:5202/api/ApplyJobCommand?NameSurname={creeteApplyJobDto.NameSurname}&Email={creeteApplyJobDto.Email}&Website={creeteApplyJobDto.Website}&AppliedAt={creeteApplyJobDto.AppliedAt}&JobId={creeteApplyJobDto.JobId}", content);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Basvurunuz Basariyla Gonderildi."; // Başarı mesajını TempData'ya ekliyoruz
            return RedirectToAction("JobDetail", new { id = creeteApplyJobDto.JobId });
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var problemDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent);

        var allErrors = problemDetails.Errors.SelectMany(e => e.Value).ToList();

        TempData["ErrorMessages"] = JsonConvert.SerializeObject(allErrors);
        return RedirectToAction("JobDetail", new { id = creeteApplyJobDto.JobId });
    }

    

}