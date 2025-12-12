using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailAboutAuthorComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _BlogDetailAboutAuthorComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            string appUser = await _context.Articles.Where(x => x.ArticleId == id).Select(y => y.AppUserId).FirstOrDefaultAsync();
            var userValue = await _context.Users.Where(x => x.Id == appUser).FirstOrDefaultAsync();
            return View(userValue);
        }
    }
}
