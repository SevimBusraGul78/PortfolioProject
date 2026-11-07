using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly PortfolioContext _context;

        public EducationController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult EducationList()
        {
            var values = _context.Educations
                                 .OrderByDescending(x => x.StartYear)
                                 .ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            CheckYears(education);
            if (!ModelState.IsValid)
            {
                return View(education);
            }

            _context.Educations.Add(education);
            _context.SaveChanges();
            TempData["Success"] = "Eğitim eklendi.";
            return RedirectToAction("EducationList");
        }

        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var value = _context.Educations.Find(id);
            if (value == null)
            {
                return RedirectToAction("EducationList");
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            CheckYears(education);
            if (!ModelState.IsValid)
            {
                return View(education);
            }

            _context.Educations.Update(education);
            _context.SaveChanges();
            TempData["Success"] = "Eğitim güncellendi.";
            return RedirectToAction("EducationList");
        }

        public IActionResult DeleteEducation(int id)
        {
            var value = _context.Educations.Find(id);
            if (value != null)
            {
                _context.Educations.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Eğitim silindi.";
            }
            return RedirectToAction("EducationList");
        }

        // Bitiş yılı başlangıçtan önce olamaz
        private void CheckYears(Education education)
        {
            if (education.EndYear.HasValue && education.EndYear < education.StartYear)
            {
                ModelState.AddModelError("EndYear", "Bitiş yılı başlangıç yılından önce olamaz.");
            }
        }
    }
}