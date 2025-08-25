using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers
{
    public class AboutItemController : Controller
    {
        private readonly InsureContext _context;

        public AboutItemController(InsureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _context.AboutItems.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAboutItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutItem(AboutItem aboutItem)
        {
            await _context.AboutItems.AddAsync(aboutItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAboutItem(int id)
        {
            var result = await _context.AboutItems.FindAsync(id);
            _context.AboutItems.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAboutItem(int id)
        {
            var value = await _context.AboutItems.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAboutItem(AboutItem aboutItem)
        {
            _context.AboutItems.Update(aboutItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
