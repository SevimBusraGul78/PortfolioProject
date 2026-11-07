using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;
using MyAcademy_PortfolioProject.Helpers;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeroSectionController : Controller
    {
        private readonly PortfolioContext _context;

        public HeroSectionController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult EditHero()
        {
            var value = _context.HeroSections.FirstOrDefault()
                        ?? new HeroSection { Greeting = "", Title = "", Description = "", MainImageUrl = "" };
            return View(value);
        }

        [HttpPost]
        public IActionResult EditHero(HeroSection hero, IFormFile? imageFile)
        {
            // Entity'de etiket olmadığı için Türkçe doğrulamayı burada yapıyoruz
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(hero.Greeting))
                ModelState.AddModelError("Greeting", "Selamlama metni zorunludur.");
            if (string.IsNullOrWhiteSpace(hero.Title))
                ModelState.AddModelError("Title", "İsim / başlık zorunludur.");
            if (string.IsNullOrWhiteSpace(hero.Description))
                ModelState.AddModelError("Description", "Tanıtım metni zorunludur.");

            var newImagePath = ImageHelper.Save(imageFile, "hero", out var imageError);
            if (imageError != null)
                ModelState.AddModelError("MainImageUrl", imageError);

            var existing = _context.HeroSections.FirstOrDefault();

            if (!ModelState.IsValid)
            {
                ImageHelper.Delete(newImagePath);
                hero.MainImageUrl = existing?.MainImageUrl ?? "";
                return View(hero);
            }

            if (existing == null)
            {
                hero.MainImageUrl = newImagePath ?? "";
                _context.HeroSections.Add(hero);
            }
            else
            {
                existing.Greeting = hero.Greeting;
                existing.Title = hero.Title;
                existing.Description = hero.Description;
                existing.HighlightValue1 = hero.HighlightValue1;
                existing.HighlightLabel1 = hero.HighlightLabel1;
                existing.HighlightValue2 = hero.HighlightValue2;
                existing.HighlightLabel2 = hero.HighlightLabel2;

                if (newImagePath != null)
                {
                    ImageHelper.Delete(existing.MainImageUrl);
                    existing.MainImageUrl = newImagePath;
                }
            }

            _context.SaveChanges();
            TempData["Success"] = "Hakkımda bilgileri kaydedildi.";
            return RedirectToAction("EditHero");
        }
    }
}