using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using X.PagedList.Extensions;

namespace InsureYouAI.ViewComponents.BlogViewComponents
{
    public class _BlogListByCategoryComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;
        public _BlogListByCategoryComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id, int page)
        {
            var values = await _context.Articles.Include(x => x.Category).Include(z => z.AppUser).Where(y => y.CategoryId == id).ToListAsync();
            return View(values.ToPagedList(page, 3));
        }
    }
}
