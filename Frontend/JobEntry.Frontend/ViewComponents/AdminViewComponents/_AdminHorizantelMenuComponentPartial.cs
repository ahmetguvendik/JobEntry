using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.AdminViewComponents;

public class _AdminHorizantelMenuComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}