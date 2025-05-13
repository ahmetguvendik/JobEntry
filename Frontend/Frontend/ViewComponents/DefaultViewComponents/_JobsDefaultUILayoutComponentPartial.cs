using JobEntry.DTO.JobDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.ViewComponents.UILayoutViewComponents;

public class _JobsDefaultUILayoutComponentPartial  : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _JobsDefaultUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5214/api/Job/Get5Job");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultGet5JobDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}