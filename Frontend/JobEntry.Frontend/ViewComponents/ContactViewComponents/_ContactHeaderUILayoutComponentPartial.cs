using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.ContactViewComponents;

public class _ContactHeaderUILayoutComponentPartial :  ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}