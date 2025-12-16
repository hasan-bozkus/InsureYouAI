using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers
{
    public class ContactController : Controller
    {
        private readonly InsureContext _context;

        public ContactController(InsureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ControllerName = "İletişim Bilgileri";
            ViewBag.PageName = "E-Posta - Telefon - Adres Bilgileri";
            var values = await _context.Contacts.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            ViewBag.ControllerName = "İletişim Bilgileri";
            ViewBag.PageName = "Yeni İletişim Biglisi Oluştur";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            ViewBag.ControllerName = "İletişim Bilgileri";
            ViewBag.PageName = "İletişim Bilgisini Güncelle";
            var value = await _context.Contacts.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
