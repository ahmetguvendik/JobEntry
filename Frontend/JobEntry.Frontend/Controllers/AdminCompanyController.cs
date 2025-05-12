using System.Text;
using JobEntry.DTO.AboutDTOs;
using JobEntry.DTO.CategoryDTOs;
using JobEntry.DTO.CompanyDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

[Authorize(Roles = "Admin")]
public class AdminCompanyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCompanyController(IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5202/api/Company");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCompanyDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    public IActionResult CreateCompany()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany(CreateCompanyDto createBannerDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBannerDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5202/api/Company", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCompany");    
        }

        return View();
           
    }
    
    
     [HttpGet]
    public async Task<IActionResult> UpdateCompany(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var response = await client.GetAsync($"http://localhost:5202/api/Company");
         var jsonData = await response.Content.ReadAsStringAsync();
         var values = JsonConvert.DeserializeObject<List<ResultCompanyDto>>(jsonData);
         List<SelectListItem> brandValue = (from x in values
             select new SelectListItem
             {
                 Text = x.Name,
                 Value = x.Id.ToString()
             }).ToList();
         ViewBag.Brands = brandValue;
         
         var responseMesage = await client.GetAsync($"http://localhost:5202/api/Company/{id}");
         if (responseMesage.IsSuccessStatusCode)
         {
             var jsonData1 = await responseMesage.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateCompanyDto>(jsonData1);
             return View(values1);
         }
         return View();
    }
        
    [HttpPost]
    public async Task<IActionResult> UpdateCompany(UpdateCompanyDto updateBannerDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBannerDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5202/api/Company", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCompany");      
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveCompany(string id)   
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5202/api/Company?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction("Error", "Home");
    }
}