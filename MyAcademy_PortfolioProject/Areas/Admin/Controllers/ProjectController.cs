using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;

        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ProjeList()
        {
            var values = _context.Projects
                                 .Include(x => x.Category)
                                 .OrderByDescending(x => x.CreatedDate)
                                 .ToList();
            return View(values);
        }

        // ---------- Yardımcı metotlar ----------

        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
        }

        private string? SaveImage(IFormFile? file, out string? error)
        {
            error = null;
            if (file == null || file.Length == 0)
                return null;

            // 1) Dosya türü kontrolü
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                error = "Sadece jpg, jpeg, png veya webp yükleyebilirsiniz.";
                return null;
            }

            // 2) Dosya boyutu kontrolü (en fazla 2 MB)
            if (file.Length > 2 * 1024 * 1024)
            {
                error = "Görsel en fazla 2 MB olabilir.";
                return null;
            }

            // 3) Güvenli dosya adı (kullanıcının verdiği isim kullanılmaz)
            var fileName = Guid.NewGuid() + extension;
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "projects");
            Directory.CreateDirectory(folder);

            using (var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // 4) Veritabanına sadece yol kaydedilir
            return "/images/projects/" + fileName;
        }

        // ---------- Ekleme ----------

        [HttpGet]
        public IActionResult CreateProject()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project, IFormFile? imageFile)
        {
            ModelState.Remove("Category");

            if (project.CategoryId == 0)
                ModelState.AddModelError("CategoryId", "Lütfen bir kategori seçiniz.");

            var imagePath = SaveImage(imageFile, out var imageError);
            if (imageError != null)
                ModelState.AddModelError("ImageUrl", imageError);

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(project);
            }

            project.ImageUrl = imagePath;
            project.CreatedDate = DateTime.Now;
            _context.Projects.Add(project);
            _context.SaveChanges();
            TempData["Success"] = "Proje eklendi.";
            return RedirectToAction("ProjeList");
        }
        // ---------- Güncelleme ----------

        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var value = _context.Projects.Find(id);
            if (value == null)
            {
                return RedirectToAction("ProjeList");
            }
            LoadCategories();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProject(Project project, IFormFile? imageFile)
        {
            ModelState.Remove("Category");

            if (project.CategoryId == 0)
                ModelState.AddModelError("CategoryId", "Lütfen bir kategori seçiniz.");

            var existing = _context.Projects.Find(project.ProjectId);
            if (existing == null)
            {
                return RedirectToAction("ProjeList");
            }

            var newImagePath = SaveImage(imageFile, out var imageError);
            if (imageError != null)
                ModelState.AddModelError("ImageUrl", imageError);

            if (!ModelState.IsValid)
            {
                DeleteImage(newImagePath);
                project.ImageUrl = existing.ImageUrl;
                LoadCategories();
                return View(project);
            }

            existing.ProjectTitle = project.ProjectTitle;
            existing.Description = project.Description;
            existing.Technologies = project.Technologies;
            existing.CategoryId = project.CategoryId;
            existing.IsActive = project.IsActive;

            if (newImagePath != null)
            {
                DeleteImage(existing.ImageUrl);
                existing.ImageUrl = newImagePath;
            }

            _context.SaveChanges();
            TempData["Success"] = "Proje güncellendi.";
            return RedirectToAction("ProjeList");
        }

        // ---------- Silme ----------

        public IActionResult DeleteProject(int id)
        {
            var value = _context.Projects.Find(id);
            if (value != null)
            {
                DeleteImage(value.ImageUrl);
                _context.Projects.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Proje silindi.";
            }
            return RedirectToAction("ProjeList");
        }

        private void DeleteImage(string? imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imageUrl.TrimStart('/'));
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }

    }
}