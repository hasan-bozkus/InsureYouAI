using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers
{
    public class AboutController : Controller
    {
        private readonly InsureContext _context;

        public AboutController(InsureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _context.Abouts.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(About About)
        {
            await _context.Abouts.AddAsync(About);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            var result = await _context.Abouts.FindAsync(id);
            _context.Abouts.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _context.Abouts.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(About About)
        {
            _context.Abouts.Update(About);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
