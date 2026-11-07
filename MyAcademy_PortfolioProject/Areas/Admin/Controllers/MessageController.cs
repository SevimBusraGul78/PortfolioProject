using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;
        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        // Listeleme + arama (en yeniden eskiye)
        public IActionResult MessageList(string? search)
        {
            var query = _context.Messages.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.SenderName.Contains(search) || x.Subject.Contains(search));
            }

            var values = query.OrderByDescending(x => x.SendDate).ToList();
            ViewBag.Search = search;
            return View(values);
        }

        // Modal için detay (sayfa yenilenmeden çağrılır) + okundu yapar
        [HttpGet]
        public IActionResult GetMessageDetail(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound();
            }

            if (!value.IsRead)
            {
                value.IsRead = true;
                _context.SaveChanges();
            }

            return Json(new
            {
                id = value.MessageId,
                senderName = value.SenderName,
                senderEmail = value.SenderEmail,
                subject = value.Subject,
                messageDetail = value.MessageDetail,
                sendDate = value.SendDate.ToString("dd.MM.yyyy HH:mm")
            });
        }

        // Okundu <-> Okunmadı
        public IActionResult ToggleRead(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                value.IsRead = !value.IsRead;
                _context.SaveChanges();
                TempData["Success"] = value.IsRead ? "Mesaj okundu olarak işaretlendi." : "Mesaj okunmadı olarak işaretlendi.";
            }
            return RedirectToAction("MessageList");
        }

        // ----- Derste yazılan metotlar (korundu) -----

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsRead = true;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public IActionResult UpdateMessage(int id)
        {
            var value = _context.Messages.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                _context.Messages.Remove(value);
                _context.SaveChanges();   // eksikti, eklendi
                TempData["Success"] = "Mesaj silindi.";
            }
            return RedirectToAction("MessageList");
        }
    }
}