using System.Security.Claims;
using JobEntry.DTO.ApplyJobDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

public class ApplyJobController : Controller
{ private readonly IHttpClientFactory _httpClientFactory;

    public ApplyJobController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    // GET
    public async Task<IActionResult> Index(string? userid)
    {
        var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
        userid = userId;
        var client = _httpClientFactory.CreateClient(); 
        var response = await client.GetAsync($"http://localhost:5214/api/ApplyJob/{userid}");   
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetApplyJobForMemberDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}