using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InsureYouAI.ViewComponents.DashboardViewComponents
{
    public class _DashobardSubWidgetsComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _DashobardSubWidgetsComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.categoryCount = await _context.Categories.CountAsync();
            ViewBag.articleCount = await _context.Articles.CountAsync();
            ViewBag.policiesCount = await _context.Policies.CountAsync();
            ViewBag.policicesByThisMonthCount = await _context.Policies.Where(p => p.CreatedDate.Month == DateTime.Now.Month && p.CreatedDate.Year == DateTime.Now.Year)
                .CountAsync();

            ViewBag.commentCount = await _context.Comments.CountAsync();
            ViewBag.lastRevenueAmount = await _context.Revenues.OrderByDescending(x => x.RevenueId).Take(1).Select(y => y.Amount).FirstOrDefaultAsync();
            ViewBag.userCount = await _context.Users.CountAsync();
            ViewBag.avgPoliciesAmount = await _context.Policies.AverageAsync(p => p.PremiumAmount);
            return View();
        }
    }
}
