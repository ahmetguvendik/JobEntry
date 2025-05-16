using JobEntry.DTO.JobDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

public class JobCategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public JobCategoryController(IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IActionResult> Index(string categoryId,int page =1 )
    {
        int pageSize = 10;
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5214/api/Job/GetJobByIdCategoryId?id={categoryId}");    

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var allJobs = JsonConvert.DeserializeObject<List<GetJobByCategoryIdDto>>(jsonData);

            // Sayfalama
            var pagedJobs = allJobs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(allJobs.Count / (double)pageSize);

            return View(pagedJobs);
        }

        return View(new List<GetJobByCategoryIdDto>());  
    }
}