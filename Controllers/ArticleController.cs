using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly InsureContext _context;

        public ArticleController(InsureContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _context.Articles.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            article.CreatedDate = DateTime.Now;

            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteArticle(int id)
        {
            var result = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int id)
        {
            var value = await _context.Articles.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArticle(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
