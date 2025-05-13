using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.UILayoutViewComponents;

public class _HeaderUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}