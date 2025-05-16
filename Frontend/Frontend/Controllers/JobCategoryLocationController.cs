using DTO.JobStyleDTOs;
using DTO.LocationDTOs;
using JobEntry.DTO.CategoryDTOs;
using JobEntry.DTO.JobDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

public class JobCategoryLocationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public JobCategoryLocationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IActionResult> Index(string categoryId,string locationId,int page =1 )    
    {
        
        var client = _httpClientFactory.CreateClient();
        int pageSize = 10;
        var response3 = await client.GetAsync($"http://localhost:5214/api/Job/GetJobByCategoryAndLocationId?categoryId={categoryId}&locationId={locationId}");    

        if (response3.IsSuccessStatusCode)
        {
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            var allJobs = JsonConvert.DeserializeObject<List<GetJobByCategoryAndLocationIdDto>>(jsonData3);

            // Sayfalama
            var pagedJobs = allJobs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(allJobs.Count / (double)pageSize);

            return View(pagedJobs);
        }   

        return View(new List<GetJobByCategoryAndLocationIdDto>());  
    }
}