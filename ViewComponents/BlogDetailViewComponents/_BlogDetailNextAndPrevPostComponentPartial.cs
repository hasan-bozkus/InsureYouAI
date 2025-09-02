using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailNextAndPrevPostComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
