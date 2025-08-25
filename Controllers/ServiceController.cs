using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly InsureContext _context;

        public ServiceController(InsureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _context.Sevices.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(Service message)
        {

            await _context.Sevices.AddAsync(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _context.Sevices.FindAsync(id);
            _context.Sevices.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _context.Sevices.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(Service message)
        {
            _context.Sevices.Update(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
