using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class BlogController : Controller
    {
        private readonly InsureContext _context;

        public BlogController(InsureContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            ViewBag.page = page;
            return View();
        }

        [HttpGet]
        public IActionResult GetBlog(string keyword)
        {
            return RedirectToAction("Index"); 
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            comment.AppUserId = "e1cfffe2-6c82-49fd-9218-bcc06003b42d";

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("BlogDetail", "Blog", new { id = comment.ArticleId });
        }
    }
}
