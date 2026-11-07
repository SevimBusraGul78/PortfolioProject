using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillItemController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillItemController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillItemList()
        {
            var values = _context.SkillItems
                                 .Include(x => x.Skill)
                                 .ToList();
            return View(values);
        }

        private void LoadSkillGroups()
        {
            ViewBag.SkillGroups = new SelectList(_context.Skills.ToList(), "SkillId", "Title");
        }

        [HttpGet]
        public IActionResult CreateSkillItem()
        {
            LoadSkillGroups();
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkillItem(SkillItem skillItem)
        {
            if (!ModelState.IsValid)
            {
                LoadSkillGroups();
                return View(skillItem);
            }

            _context.SkillItems.Add(skillItem);
            _context.SaveChanges();
            TempData["Success"] = "Yetenek başarıyla eklendi.";
            return RedirectToAction("SkillItemList");
        }
        [HttpGet]
        public IActionResult UpdateSkillItem(int id)
        {
            var value = _context.SkillItems.Find(id);
            if (value == null)
            {
                return RedirectToAction("SkillItemList");
            }
            LoadSkillGroups();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSkillItem(SkillItem skillItem)
        {
            if (!ModelState.IsValid)
            {
                LoadSkillGroups();
                return View(skillItem);
            }

            _context.SkillItems.Update(skillItem);
            _context.SaveChanges();
            TempData["Success"] = "Yetenek güncellendi.";
            return RedirectToAction("SkillItemList");
        }

        public IActionResult DeleteSkillItem(int id)
        {
            var value = _context.SkillItems.Find(id);
            if (value != null)
            {
                _context.SkillItems.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Yetenek silindi.";
            }
            return RedirectToAction("SkillItemList");
        }
    }
}