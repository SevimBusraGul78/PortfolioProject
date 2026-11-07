using Microsoft.AspNetCore.Mvc;

namespace MyAcademy_PortfolioProject.ViewComponents.DefaultViewCompenents
{
    public class _DefaultStyleComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
             return View(); 
        }
    }
}
