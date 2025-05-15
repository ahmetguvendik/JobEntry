using System.Security.Claims;
using System.Text;
using DTO.JobStyleDTOs;
using DTO.JobTypeDTOs;
using DTO.LocationDTOs;
using JobEntry.DTO.CategoryDTOs;
using JobEntry.DTO.CompanyDTOs;
using JobEntry.DTO.JobDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

public class CompanyCreateJobController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CompanyCreateJobController(IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5214/api/Location");
        var jsonData = await response.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
        List<SelectListItem> locations = (from x in values
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.Locations = locations;
        
        var response2 = await client.GetAsync("http://localhost:5214/api/JobStyle");
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        var values2 = JsonConvert.DeserializeObject<List<ResultJobStyleDto>>(jsonData2);
        List<SelectListItem> JobStyle = (from x in values2  
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.JobStyles = JobStyle;
        
        var response3 = await client.GetAsync("http://localhost:5214/api/JobType");
        var jsonData3 = await response3.Content.ReadAsStringAsync();
        var values3 = JsonConvert.DeserializeObject<List<ResultJobTypeDto>>(jsonData3);
        List<SelectListItem> jobtype = (from x in values3  
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.JobTypes = jobtype;
        
        var response4 = await client.GetAsync("http://localhost:5214/api/Category");
        var jsonData4 = await response4.Content.ReadAsStringAsync();
        var values4 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData4);
        List<SelectListItem> category = (from x in values4
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();    
        ViewBag.Categories = category;
        
        var userId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
        
        var response5 = await client.GetAsync($"http://localhost:5214/api/Company/GetCompanyByUserId/{userId}");
        var jsonData5 = await response5.Content.ReadAsStringAsync();
        var values5 = JsonConvert.DeserializeObject<List<GetCompanyByIdDto>>(jsonData5);
        List<SelectListItem> company = (from x in values5
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();    
        ViewBag.Company = company;
        
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateJobDto createJobDto)
    {
        createJobDto.PublishedTime = DateTime.Now;
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createJobDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5214/api/Job", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Company");    
        }

        return View();
           
    }
}