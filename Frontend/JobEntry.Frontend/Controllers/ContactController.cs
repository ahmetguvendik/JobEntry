using System.Net;
using System.Text;
using JobEntry.DTO.CommentDTOs;
using JobEntry.DTO.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ContactController( IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;    
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5202/api/Contact");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    public PartialViewResult CreateComment()
    {
        return PartialView(new CreateCommentDto());
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
    {
        createCommentDto.CreatedTime = DateTime.UtcNow;

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCommentDto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("http://localhost:5202/api/Comment", stringContent);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi.";
            return RedirectToAction("Index");
        }
        else
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var problemDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent);

            var allErrors = problemDetails.Errors.SelectMany(e => e.Value).ToList();

            TempData["ErrorMessages"] = JsonConvert.SerializeObject(allErrors); // Listeyi serialize et
            return RedirectToAction("Index");
        }
    }
}
    