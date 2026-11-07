using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;

namespace MyAcademy_PortfolioProject.ViewComponents.DefaultViewCompenents
{
    public class _DefaultHeroSectionComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultHeroSectionComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            var value = _context.HeroSections.FirstOrDefault()
                        ?? new Entites.HeroSection { Greeting = "", Title = "", Description = "", MainImageUrl = "" };

            ViewBag.greeting = value.Greeting;
            ViewBag.title = value.Title;
            ViewBag.description = value.Description;
            ViewBag.mainImageUrl = value.MainImageUrl;

            // Yeni eklenenler
            ViewBag.highlightValue1 = value.HighlightValue1;
            ViewBag.highlightLabel1 = value.HighlightLabel1;
            ViewBag.highlightValue2 = value.HighlightValue2;
            ViewBag.highlightLabel2 = value.HighlightLabel2;
            ViewBag.socialMedias = _context.SocialMedias.ToList();

            return View();
        }
    }
}