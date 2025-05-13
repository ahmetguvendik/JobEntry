using JobEntry.DTO.BannerDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.ViewComponents.UILayoutViewComponents;

public class _CarauselUILayoutComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CarauselUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5214/api/Banner");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}