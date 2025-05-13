using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}