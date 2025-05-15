using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.Controllers;

public class CompanyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}