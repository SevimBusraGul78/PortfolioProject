using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly PortfolioContext _context;

        public SocialMediaController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SocialMediaList()
        {
            return View(_context.SocialMedias.ToList());
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View(socialMedia);
            }

            _context.SocialMedias.Add(socialMedia);
            _context.SaveChanges();
            TempData["Success"] = "Bağlantı eklendi.";
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            if (value == null)
            {
                return RedirectToAction("SocialMediaList");
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View(socialMedia);
            }

            _context.SocialMedias.Update(socialMedia);
            _context.SaveChanges();
            TempData["Success"] = "Bağlantı güncellendi.";
            return RedirectToAction("SocialMediaList");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            if (value != null)
            {
                _context.SocialMedias.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Bağlantı silindi.";
            }
            return RedirectToAction("SocialMediaList");
        }
    }
}