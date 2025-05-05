using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.UILayoutViewComponents;

public class _AboutDefaultUILayoutComponentPartial  : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}