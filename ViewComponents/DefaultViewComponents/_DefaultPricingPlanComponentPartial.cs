using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.DefaultViewComponents
{
    public class _DefaultPricingPlanComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _DefaultPricingPlanComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.PricingPlans.Where(x => x.IsFEature == true).ToListAsync();
            return View(values);
        }
    }
}
