using System.Security.Claims;
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

    public CompanyApplyJobController(IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
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

}