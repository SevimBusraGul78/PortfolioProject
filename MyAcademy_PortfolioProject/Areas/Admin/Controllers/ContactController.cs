using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("ContactList");   
        }
        // ----- Tekil kayıt: güncelleme odaklı yönetim -----

        [HttpGet]
        public IActionResult EditContact()
        {
            var value = _context.Contacts.FirstOrDefault() ?? new Contact();
            return View(value);
        }

        [HttpPost]
        public IActionResult EditContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            if (contact.ContactId == 0)
            {
                _context.Contacts.Add(contact);      // ilk kez kaydediliyor
            }
            else
            {
                _context.Contacts.Update(contact);   // mevcut kayıt güncelleniyor
            }

            _context.SaveChanges();
            TempData["Success"] = "İletişim bilgileri kaydedildi.";
            return RedirectToAction("EditContact");
        }
    }
}