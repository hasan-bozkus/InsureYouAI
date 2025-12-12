using InsureYouAI.Context;
using InsureYouAI.Entities;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InsureYouAI.ViewComponents.BlogViewComponents
{
    public class _BlogListCategoriesComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _BlogListCategoriesComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var values = await _context.Categories.ToListAsync();
            var values = await _context.Categories.Select(c => new CategoryArticleCountViewModel
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                ArticleCount = c.Articles.Count()
            }).ToListAsync();
            return View(values);
        }
    }
}
