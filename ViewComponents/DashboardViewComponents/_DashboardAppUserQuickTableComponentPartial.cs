using InsureYouAI.Context;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.DashboardViewComponents
{
    public class _DashboardAppUserQuickTableComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _DashboardAppUserQuickTableComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Users.GroupJoin(
                 _context.Policies,
                 user => user.Id,
                 policy => policy.AppUserId,
                 (user, policies) => new UserPolicySummaryViewModel
                 {
                     UserId = user.Id,
                     FullName = user.Name + " " + user.Surame,
                     ImageUrl = user.ImageUrl,
                     PolicyCount = policies.Count(),
                     TotalPremium = policies.Sum(p => (decimal?)p.PremiumAmount) ?? 0
                 }).OrderByDescending(x => x.PolicyCount).ToListAsync();

            return View(values);
        }
    }
}
