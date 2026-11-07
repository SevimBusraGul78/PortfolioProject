using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;
using MyAcademy_PortfolioProject.Helpers;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult EditAbout()
        {
            var value = _context.Abouts.FirstOrDefault() ?? new About();
            return View(value);
        }

        [HttpPost]
        public IActionResult EditAbout(About about, IFormFile? imageFile)
        {
            var newImagePath = ImageHelper.Save(imageFile, "about", out var imageError);
            if (imageError != null)
                ModelState.AddModelError("ImageUrl", imageError);

            var existing = _context.Abouts.FirstOrDefault();

            if (!ModelState.IsValid)
            {
                ImageHelper.Delete(newImagePath);
                about.ImageUrl = existing?.ImageUrl;
                return View(about);
            }

            if (existing == null)
            {
                about.ImageUrl = newImagePath;
                _context.Abouts.Add(about);
            }
            else
            {
                existing.Heading = about.Heading;
                existing.Content = about.Content;
                existing.Caption = about.Caption;
                existing.JobTitle = about.JobTitle;
                existing.Stat1Value = about.Stat1Value;
                existing.Stat1Label = about.Stat1Label;
                existing.Stat2Value = about.Stat2Value;
                existing.Stat2Label = about.Stat2Label;
                existing.Stat3Value = about.Stat3Value;
                existing.Stat3Label = about.Stat3Label;
                existing.CvUrl = about.CvUrl;

                if (newImagePath != null)
                {
                    ImageHelper.Delete(existing.ImageUrl);
                    existing.ImageUrl = newImagePath;
                }
            }

            _context.SaveChanges();
            TempData["Success"] = "Hakkımda bölümü kaydedildi.";
            return RedirectToAction("EditAbout");
        }
    }
}