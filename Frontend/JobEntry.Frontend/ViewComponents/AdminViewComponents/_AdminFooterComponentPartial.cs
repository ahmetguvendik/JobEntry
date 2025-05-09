using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.AdminViewComponents;

public class _AdminFooterComponentPartial  : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}