using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;

        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ExperienceList()
        {
            var values = _context.Experiences
                                 .OrderByDescending(x => x.ExperienceId)
                                 .ToList();
            return View(values);
        }

        // Entity'de Data Annotation olmadığı için Türkçe doğrulamayı burada yapıyoruz
        private void ValidateExperience(Experience experience)
        {
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(experience.Title))
                ModelState.AddModelError("Title", "Pozisyon/başlık zorunludur.");
            if (string.IsNullOrWhiteSpace(experience.CompanyName))
                ModelState.AddModelError("CompanyName", "Şirket adı zorunludur.");
            if (string.IsNullOrWhiteSpace(experience.CategoryName))
                ModelState.AddModelError("CategoryName", "Çalışma türü seçiniz.");
            if (string.IsNullOrWhiteSpace(experience.Description))
                ModelState.AddModelError("Description", "Açıklama zorunludur.");
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View(new Experience { IsActive = true });
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            ValidateExperience(experience);
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            _context.Experiences.Add(experience);
            _context.SaveChanges();
            TempData["Success"] = "Deneyim eklendi.";
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            if (value == null)
            {
                return RedirectToAction("ExperienceList");
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            ValidateExperience(experience);
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            _context.Experiences.Update(experience);
            _context.SaveChanges();
            TempData["Success"] = "Deneyim güncellendi.";
            return RedirectToAction("ExperienceList");
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            if (value != null)
            {
                _context.Experiences.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Deneyim silindi.";
            }
            return RedirectToAction("ExperienceList");
        }
    }
}