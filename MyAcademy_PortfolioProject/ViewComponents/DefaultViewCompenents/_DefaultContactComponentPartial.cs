using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entites;

namespace MyAcademy_PortfolioProject.ViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultContactComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SocialMedias = _context.SocialMedias.ToList();
            var contact = _context.Contacts.FirstOrDefault() ?? new Contact { Email = "" };
            return View(contact);
        }
    }
}