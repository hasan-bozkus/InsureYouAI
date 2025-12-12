using InsureYouAI.Context;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace InsureYouAI.ViewComponents.BlogViewComponents
{
    public class _BlogListAllBlogsComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _BlogListAllBlogsComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int page)
        {
            //var values = await _context.Articles.Include(x => x.Category).Include(y => y.AppUser).ToListAsync();
            var values = await _context.Articles.Include(x => x.Category).Include(y => y.AppUser).Include(z => z.Comments).Select(a => new ArticleListViewModel
            {
                ArticleId = a.ArticleId,
                Author = a.AppUser.Name + " " + a.AppUser.Surame,
                CategoryName = a.Category.CategoryName,
                CreatedDate = a.CreatedDate,
                Content = a.Content,
                ImageUrl = a.CoverImageUrl,
                Title = a.Title,
                CommentCount = a.Comments.Count()
            }).ToArrayAsync();
            return View(values.ToPagedList(page, 3));
        }
    }
}
