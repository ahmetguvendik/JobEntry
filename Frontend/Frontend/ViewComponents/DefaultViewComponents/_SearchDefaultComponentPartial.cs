using DTO.LocationDTOs;
using JobEntry.DTO.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace JobEntry.Frontend.ViewComponents.UILayoutViewComponents;

public class _SearchDefaultComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _SearchDefaultComponentPartial(IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()       
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
        
        var response2 = await client.GetAsync("http://localhost:5214/api/Category");
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
        List<SelectListItem> category = (from x in values2  
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.Categories = category;
        
        return View();
    }
}