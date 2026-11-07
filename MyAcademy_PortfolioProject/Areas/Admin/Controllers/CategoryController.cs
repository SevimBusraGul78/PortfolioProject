using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly PortfolioContext _context;

        public CategoryController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                ModelState.AddModelError("CategoryName", "Kategori adı zorunludur");
                return View(category);
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["Success"] = "Kategori eklendi.";
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
            {
                return RedirectToAction("CategoryList");
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                ModelState.AddModelError("CategoryName", "Kategori adı zorunludur");
                return View(category);
            }

            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["Success"] = "Kategori güncellendi.";
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            if (value != null)
            {
                _context.Categories.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Kategori silindi.";
            }
            return RedirectToAction("CategoryList");
        }
    }
}