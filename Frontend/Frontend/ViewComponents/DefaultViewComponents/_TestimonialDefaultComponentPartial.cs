using JobEntry.DTO.TestimonialDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.ViewComponents.UILayoutViewComponents;

public class _TestimonialDefaultComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _TestimonialDefaultComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
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
}