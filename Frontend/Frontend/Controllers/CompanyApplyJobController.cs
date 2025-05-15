using System.Security.Claims;
using System.Text;
using JobEntry.Application.Services;
using JobEntry.DTO.ApplyJobDTOs;
using JobEntry.DTO.CompanyDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

[Authorize(Roles = "Company")]
public class CompanyApplyJobController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IEmailService  _emailService;



    public CompanyApplyJobController(IHttpClientFactory httpClientFactory, IEmailService emailService)
    {
         _httpClientFactory = httpClientFactory;
         _emailService = emailService;
    }
    
    public async Task<IActionResult> Index(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
        
        var response5 = await client.GetAsync($"http://localhost:5214/api/Company/GetCompanyByUserId/{userId}");
        var jsonData5 = await response5.Content.ReadAsStringAsync();
        var companies = JsonConvert.DeserializeObject<List<GetCompanyByIdDto>>(jsonData5);
        if (companies != null && companies.Any())
        {
            var company = companies.First();
             id = company.Id;
        }

        
        var response = await client.GetAsync($"http://localhost:5214/api/ApplyJob/GetApplyJobByICategoryId/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetApplyJobByCompanyIdDto>>(jsonData);
            return View(values);
            
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> SendMailAndOpenCV(string email, string cvPath, string JobName,string CompanyName,string id, UpdateApplyJobDto dto)
    {
        // Mail gönder
       await _emailService.SendSeenAppEmailAsync(email, $"CV Görüntülendi, CV görüntüleme gerçekleşti Basvurdugunuz Is: {JobName} Basvurulan Sirket: {CompanyName}");
       var client = _httpClientFactory.CreateClient();
       dto.Id = id; 
       var jsonData = JsonConvert.SerializeObject(dto);
       StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
       await client.PutAsync("http://localhost:5214/api/ApplyJob", stringContent);
       
        // CV dosyasını yeni pencerede aç
        // Burada ya doğrudan dosyanın url'sini dönebilirsin, ya da redirect ile yönlendirme yapabilirsin
        // Örnek redirect:
        return Redirect($"http://localhost:5214/{cvPath}");
    }

}