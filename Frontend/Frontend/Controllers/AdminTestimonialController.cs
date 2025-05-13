using System.Text;
using JobEntry.DTO.AboutDTOs;
using JobEntry.DTO.TestimonialDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

[Authorize(Roles = "Admin")]
public class AdminTestimonialController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminTestimonialController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5214/api/Testimonial");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
       public IActionResult CreateTestimonial()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createBannerDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBannerDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5214/api/Testimonial", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminTestimonial");    
        }

        return View();
           
    }
    
    
     [HttpGet]
    public async Task<IActionResult> UpdateTestimonial(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var response = await client.GetAsync($"http://localhost:5214/api/Testimonial");
         var jsonData = await response.Content.ReadAsStringAsync();
         var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
         List<SelectListItem> brandValue = (from x in values
             select new SelectListItem
             {
                 Text = x.Name,
                 Value = x.Id.ToString()
             }).ToList();
         ViewBag.Brands = brandValue;
         
         var responseMesage = await client.GetAsync($"http://localhost:5214/api/Testimonial/{id}");
         if (responseMesage.IsSuccessStatusCode)
         {
             var jsonData1 = await responseMesage.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData1);
             return View(values1);
         }
         return View();
    }
        
    [HttpPost]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateBannerDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBannerDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5214/api/Testimonial", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminTestimonial");      
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveTestimonial(string id)   
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5214/api/Testimonial?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction("Error", "Home");
    }
}