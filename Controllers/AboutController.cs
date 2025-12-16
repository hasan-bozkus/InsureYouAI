using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InsureYouAI.Controllers
{
    public class AboutController : Controller
    {
        private readonly InsureContext _context;

        public AboutController(InsureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ControllerName = "Hakkımızda";
            ViewBag.PageName = "Hakkımızda Listesi";
            var values = await _context.Abouts.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            ViewBag.AboutCount = await _context.Abouts.CountAsync();
            ViewBag.ControllerName = "Hakkımızda";
            ViewBag.PageName = "Yeni Hakkımızda Oluştur (Tema Bütünlüğünü Korumak İçin 1 Adet Hakkımızda Yazısı Giriniz.)";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(About About)
        {
            if (await _context.Abouts.AnyAsync())
            {
                return View(About);
            }
            await _context.Abouts.AddAsync(About);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            var result = await _context.Abouts.FindAsync(id);
            _context.Abouts.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            ViewBag.ControllerName = "Hakkımızda";
            ViewBag.PageName = "Hakkımızda Güncelleme Sayfsaı";
            var value = await _context.Abouts.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(About About)
        {
            _context.Abouts.Update(About);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateAboutWithGoogleGemini()
        {
            ViewBag.ControllerName = "Hakkımızda";
            ViewBag.PageName = "Yapay Zeka ile Hakkımızda Oluştur (Tema Bütünlüğünü Korumak İçin 1 Adet Hakkımızda Yazısı Giriniz.)";

            //anahtar ezildi
            var apiKey = "AIzaSyCWnN59rffSSTsv_fH68Y8xazAudMGKyUE";
            var model = "gemini-1.5-pro";
            var url = $"https://generativelanguage.googleapis.com/v1/models/{model}:generateContent?key={apiKey}";
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = "Kurumsal bir sigorta firması için etkileyici, güven verici ve profesyonel bir 'Hakkımızda' yazısı oluştur."}
                        }
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PostAsync(url, content);
            var responseJson = await response.Content.ReadAsStringAsync();

            using var jsonDoc = JsonDocument.Parse(responseJson);
            var aboutText = jsonDoc
                .RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();
            ViewBag.value = aboutText;

            return View();
        }
    }
}
//$"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={apiKey}"

//apiKey = "AIzaSyCWnN59rffSSTsv_fH68Y8xazAudMGKyUE";