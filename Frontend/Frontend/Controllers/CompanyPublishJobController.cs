using System.Security.Claims;
using JobEntry.DTO.CompanyDTOs;
using JobEntry.DTO.JobDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

[Authorize(Roles = "Company")]
public class CompanyPublishJobController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CompanyPublishJobController(IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    
    // GET
    public async Task<IActionResult> Index(string companyId)
    {
        var client = _httpClientFactory.CreateClient();
        var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
        
        var response5 = await client.GetAsync($"http://localhost:5214/api/Company/GetCompanyByUserId/{userId}");
        var jsonData5 = await response5.Content.ReadAsStringAsync();
        var companies = JsonConvert.DeserializeObject<List<GetCompanyByIdDto>>(jsonData5);
        if (companies != null && companies.Any())
        {
            var company = companies.First();
            companyId = company.Id;
        }

        
        var response = await client.GetAsync($"http://localhost:5214/api/Job/GetJobByCompanyId/{companyId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetJobByCompanyIdDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
}