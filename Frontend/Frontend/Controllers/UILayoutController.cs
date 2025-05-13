using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.Controllers;

public class UILayoutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}