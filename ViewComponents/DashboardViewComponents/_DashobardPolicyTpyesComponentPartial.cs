using InsureYouAI.Context;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.DashboardViewComponents
{
    public class _DashobardPolicyTpyesComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _DashobardPolicyTpyesComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Policies.GroupBy(x=> x.PolicyType).Select(y => new PolicyGroupViewModel
            {
                PolicyType = y.Key,
                Count = y.Count()
            }).ToListAsync();

            ViewBag.TotalPolicyCount = values.Sum(x => x.Count);

            return View(values);
        }
    }
}
