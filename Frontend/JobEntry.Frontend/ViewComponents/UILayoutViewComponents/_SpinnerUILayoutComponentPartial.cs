using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.UILayoutViewComponents;

public class _SpinnerUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}