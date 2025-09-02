using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailCommentListComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
