using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailNextAndPrevPostComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _BlogDetailNextAndPrevPostComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var article = await _context.Articles.Where(x => x.ArticleId == id).FirstOrDefaultAsync();

            var prvArticle = await _context.Articles.Where(x => x.ArticleId < id).OrderByDescending(y => y.ArticleId).Select(z =>z.Title).FirstOrDefaultAsync();

            var nextArticle = await _context.Articles.Where(x => x.ArticleId > id).OrderBy(y => y.ArticleId).Select(z => z.Title).FirstOrDefaultAsync();

            ViewBag.PrevArticleTitle = prvArticle;
            ViewBag.NextArticleTitle = nextArticle;

            return View();
        }
    }
}
