using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.Controllers;

public class AdminLayoutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}