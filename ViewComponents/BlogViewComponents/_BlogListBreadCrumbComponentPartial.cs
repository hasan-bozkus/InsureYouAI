using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsureYouAI.ViewComponents.BlogViewComponents
{
    public class _BlogListBreadCrumbComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View();
        }
    }
}
