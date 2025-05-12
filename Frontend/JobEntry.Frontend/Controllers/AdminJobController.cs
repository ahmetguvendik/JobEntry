using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.Controllers;

[Authorize(Roles = "Admin")]
public class AdminJobController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}