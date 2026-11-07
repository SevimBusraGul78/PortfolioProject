using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;

namespace MyAcademy_PortfolioProject.ViewComponents
{
    public class _DefaultSkillComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultSkillComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Skills
                                 .Include(x => x.SkillItems)
                                 .ToList();
            return View(values);
        }
    }
}