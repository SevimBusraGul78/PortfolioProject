using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;

namespace MyAcademy_PortfolioProject.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutSideBarComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _AdminLayoutSideBarComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.UnreadCount = _context.Messages.Count(x => !x.IsRead);
            return View();
        }
    }
}