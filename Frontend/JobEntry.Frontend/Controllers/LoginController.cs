using JobEntry.DTO.AppUserDTOs;
using JobEntry.Application.Features.CQRS.Results.AppUserResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace JobEntry.Frontend.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        // GET: /Login
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Login
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                var response = await client.PostAsJsonAsync("http://localhost:5202/api/Login", loginUserDto);

                if (response.IsSuccessStatusCode)
                {
                    var loginResult = await response.Content.ReadFromJsonAsync<LoginUserQueryResult>();

                    if (loginResult != null)
                    {
                        // 🔐 Claims oluşturuluyor
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, loginUserDto.Username),
                            new Claim(ClaimTypes.Role, loginResult.Role)
                        };

                        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                        var principal = new ClaimsPrincipal(identity);

                        // 🔐 Kullanıcı oturum açıyor
                        await HttpContext.SignInAsync("MyCookieAuth", principal);

                        // Rol bazlı yönlendirme
                        return loginResult.Role switch
                        {
                            "Admin" => RedirectToAction("Index", "AdminJob"),
                            "Company" => RedirectToAction("Index", "About"),
                            "Member" => RedirectToAction("Index", "Default"),
                            _ => RedirectToAction("Index", "Login")
                        };
                    }
                    else
                    {
                        ViewBag.Error = "Kullanıcı adı ya da şifre hatalı.";
                    }
                }
                else
                {
                    var errorText = await response.Content.ReadAsStringAsync();
                    ViewBag.Error = "Sunucudan hata döndü: " + errorText;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "İstek sırasında beklenmeyen bir hata oluştu: " + ex.Message;
            }

            return View();
        }

        // Opsiyonel: çıkış işlemi
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "Login");
        }
    }
}
