using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DashboardViewComponents
{
    public class _DashboardRadialChartComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
