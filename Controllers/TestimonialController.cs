using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly InsureContext _context;

        public TestimonialController(InsureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _context.Testimonials.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(Testimonial testimonial)
        {

            await _context.Testimonials.AddAsync(testimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var result = await _context.Testimonials.FindAsync(id);
            _context.Testimonials.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _context.Testimonials.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
