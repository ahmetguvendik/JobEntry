using System.Text;
using JobEntry.DTO.AppUserDTOs;
using JobEntry.DTO.CompanyDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobEntry.Frontend.Controllers;

public class RegisterController : Controller
{
    private readonly IHttpClientFactory  _httpClientFactory;

    public RegisterController(IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult>Index(CreateUserDto createUserDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createUserDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5214/api/Register", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Login");    
        }

        return View();
    }
    
}