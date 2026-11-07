using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;

namespace MyAcademy_PortfolioProject.ViewComponents.DefaultViewCompenents
{
    public class _DefaultExperienceComponentPartial:ViewComponent
    {
            private readonly PortfolioContext _context;
            public _DefaultExperienceComponentPartial(PortfolioContext context)
            {
                _context = context;
            }

            public IViewComponentResult Invoke()
            {
            var values = _context.Experiences
                                 .Where(x => x.IsActive)
                                 .OrderByDescending(x => x.ExperienceId)
                                 .ToList(); return View(values);
            }
        }
    }

