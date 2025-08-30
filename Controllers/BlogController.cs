using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index(int page = 1)
        {
            ViewBag.page = page;
            return View();
        }

        [HttpGet]
        public IActionResult GetBlog(string keyword)
        {
            return RedirectToAction("Index"); 
        }
    }
}
