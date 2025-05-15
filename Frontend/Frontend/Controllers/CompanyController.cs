using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.Controllers;

[Authorize(Roles = "Company")]
public class CompanyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}