using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            _context.Skills.Add(skill);
            _context.SaveChanges();
            TempData["Success"] = "Yetenek grubu başarıyla eklendi.";
            return RedirectToAction("SkillList");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var value = _context.Skills.Find(id);
            if (value == null)
            {
                return RedirectToAction("SkillList");
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            _context.Skills.Update(skill);
            _context.SaveChanges();
            TempData["Success"] = "Yetenek grubu güncellendi.";
            return RedirectToAction("SkillList");

        }
        public IActionResult DeleteSkill(int id)
        {
            var value = _context.Skills.Find(id);
            if (value != null)
            {
                _context.Skills.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Yetenek grubu silindi.";
            }
            return RedirectToAction("SkillList");
        }
    }
}