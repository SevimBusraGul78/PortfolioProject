using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Areas.Admin.Models;
using MyAcademy_PortfolioProject.Context;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Derste yazılan sorgular (korundu)
            ViewBag.v1 = _context.Messages.Count();
            ViewBag.v2 = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v3 = _context.Messages.Where(x => x.IsRead == true).Count();

            var model = new DashboardViewModel
            {
                // ---- Count / Where ----
                TotalProjectCount = _context.Projects.Count(),
                ActiveProjectCount = _context.Projects.Count(x => x.IsActive),
                SkillCount = _context.SkillItems.Count(),
                ExperienceCount = _context.Experiences.Count(),
                EducationCount = _context.Educations.Count(),
                TotalMessageCount = _context.Messages.Count(),
                UnreadMessageCount = _context.Messages.Count(x => !x.IsRead),

                // ---- OrderByDescending + Take: son 5 mesaj ----
                LastMessages = _context.Messages
                                       .OrderByDescending(x => x.SendDate)
                                       .Take(5)
                                       .ToList(),

                // ---- Include + OrderByDescending + Take: son 3 proje ----
                LastProjects = _context.Projects
                                       .Include(x => x.Category)
                                       .OrderByDescending(x => x.CreatedDate)
                                       .Take(3)
                                       .ToList(),

                // ---- GroupBy: her kategoride kaç proje var ----
                CategorySummaries = _context.Projects
                                            .GroupBy(x => x.Category.CategoryName)
                                            .Select(g => new CategorySummary
                                            {
                                                CategoryName = g.Key,
                                                ProjectCount = g.Count()
                                            })
                                            .OrderByDescending(x => x.ProjectCount)
                                            .ToList()
            };

            return View(model);
        }
    }
}