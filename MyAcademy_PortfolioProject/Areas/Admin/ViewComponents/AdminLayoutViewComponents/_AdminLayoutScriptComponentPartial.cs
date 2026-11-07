using Microsoft.AspNetCore.Mvc;

namespace MyAcademy_PortfolioProject.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{

    public class _AdminLayoutScriptComponentPartial:ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View("~/Areas/Admin/Views/Shared/Components/_AdminLayoutScriptComponentPartial/Default.cshtml");
        }
    }
}
