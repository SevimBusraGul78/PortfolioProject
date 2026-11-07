using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;

namespace MyAcademy_PortfolioProject.ViewComponents
{
    public class _DefaultProjectComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultProjectComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Projects
                                 .Include(x => x.Category)
                                 .Where(x => x.IsActive)
                                 .OrderByDescending(x => x.CreatedDate)
                                 .ToList();
            return View(values);
        }
    }
}