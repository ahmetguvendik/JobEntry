using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.AdminViewComponents;

public class _AdminScriptComponentPartial  : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}