using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.UILayoutViewComponents;

public class _ScriptUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}