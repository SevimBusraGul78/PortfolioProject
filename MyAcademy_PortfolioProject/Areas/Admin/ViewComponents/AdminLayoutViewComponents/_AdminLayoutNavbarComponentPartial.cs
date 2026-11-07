using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace MyAcademy_PortfolioProject.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View(); 
        }
        
    }
}
