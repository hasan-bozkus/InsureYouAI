using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InsureYouAI.Controllers
{
    public class CommentController : Controller
    {
        private readonly InsureContext _context;

        public CommentController(InsureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _context.Comments.Include(x => x.AppUser).Include(y => y.Article).ToListAsync();
            return View(values);
        }
    }
}
