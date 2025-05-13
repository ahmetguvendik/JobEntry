using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.UILayoutViewComponents;

public class _SearchDefaultComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}