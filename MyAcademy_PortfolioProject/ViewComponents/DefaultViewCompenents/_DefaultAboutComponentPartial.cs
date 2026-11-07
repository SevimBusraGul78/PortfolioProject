using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.ViewComponents.DefaultViewCompenents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultAboutComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Abouts.FirstOrDefault()
                        ?? new About { Heading = "", Content = "" };

            // About'a fotoğraf yüklenmemişse, ana sayfadaki fotoğrafı kullan
            if (string.IsNullOrEmpty(value.ImageUrl))
            {
                value.ImageUrl = _context.HeroSections.Select(x => x.MainImageUrl).FirstOrDefault();
            }

            return View(value);
        }
    }
}