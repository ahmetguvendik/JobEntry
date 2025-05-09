using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.Controllers;

public class AdminJobController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}