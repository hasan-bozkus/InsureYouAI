using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.DefaultViewComponents
{
    public class _DefaultGalleryComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _DefaultGalleryComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Galleries.ToListAsync();
            return View(values);
        }
    }
}
