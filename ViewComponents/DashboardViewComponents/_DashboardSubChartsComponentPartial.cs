using InsureYouAI.Context;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.DashboardViewComponents
{
    public class _DashboardSubChartsComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _DashboardSubChartsComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {            
            return View();
        }
    }
}
