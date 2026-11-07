using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly PortfolioContext _context;

        public DefaultController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                // Hangi alanda hangi hata var: { "SenderEmail": "Geçerli bir e-posta adresi giriniz", ... }
                var errors = ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(x => x.Key, x => x.Value.Errors.First().ErrorMessage);

                return Json(new { success = false, errors });
            }

            message.SendDate = DateTime.Now;
            message.IsRead = false;   // yeni mesaj = okunmamış
            _context.Messages.Add(message);
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
