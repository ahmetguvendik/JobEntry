using Microsoft.AspNetCore.Mvc;

namespace JobEntry.Frontend.ViewComponents.JobViewComponents;

public class _JobHeaderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}