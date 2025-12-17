using InsureYouAI.Context;
using InsureYouAI.Entities;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InsureYouAI.Controllers
{
    public class PricingPlanController : Controller
    {
        private readonly InsureContext _context;
        private readonly string _openAiApiKey = "anahtar ezildi";

        public PricingPlanController(InsureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ControllerName = "AI Destekli Sigorta Planı";
            ViewBag.PageName = "Mevcut Sigorta Plan Listeleri";
            var values = await _context.PricingPlans.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePricingPlan()
        {
            ViewBag.ControllerName = "AI Destekli Sigorta Planı";
            ViewBag.PageName = "Yeni Sigorta Planı Oluşturma";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricingPlan(PricingPlan pricingPlan)
        {
            pricingPlan.IsFEature = false;

            await _context.PricingPlans.AddAsync(pricingPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePricingPlan(int id)
        {
            var result = await _context.PricingPlans.FindAsync(id);
            _context.PricingPlans.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePricingPlan(int id)
        {
            ViewBag.ControllerName = "AI Destekli Sigorta Planı";
            ViewBag.PageName = "Sigorta Plan Revizyonu";
            var value = await _context.PricingPlans.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePricingPlan(PricingPlan pricingPlan)
        {
            _context.PricingPlans.Update(pricingPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            var value = await _context.PricingPlans.FindAsync(id);
            if(value.IsFEature == true)
            {
                value.IsFEature = false;
            }
            else
            {
                value.IsFEature = true;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PricingPlan");
        }

        [HttpGet]
        public async Task<IActionResult> CreateUserCustomizePlan()
        {
            ViewBag.ControllerName = "AI Destekli Sigorta Planı";
            ViewBag.PageName = "Kullanıcıya Özel AI Destekli Sigorta Planı Belirleme";
            var model = new AIInsuranceRecommendationViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserCustomizePlan(AIInsuranceRecommendationViewModel model)
        {
            ViewBag.ControllerName = "AI Destekli Sigorta Planı";
            ViewBag.PageName = "Kullanıcıya Özel AI Destekli Sigorta Planı Belirleme";

            // Kullanıcı girdilerini JSON'a çeviriyoruz
            var userJson = JsonConvert.SerializeObject(model);

            // OpenAI'ye göndereceğimiz prompt:
            var prompt = $@"
Sen profesyonel bir sigorta uzmanı AI asistanısın. 
Aşağıdaki kullanıcının bilgilerini analiz ederek en uygun sigorta paketini öner.

Paketler ve özellikleri:
1) Premium Paket (599 TL/ay): Yatarak tedavi, check-up, geniş yol yardım, yurtiçi seyahat güvencesi.
2) Standart Paket (449 TL/ay): Acil sağlık, müşteri hizmetleri, kaza sonrası tıbbi destek.
3) Ekonomik Paket (339 TL/ay): Temel sağlık, temel yol yardım.

Kullanıcı bilgileri:
{userJson}

Sadece şu formatta JSON döndür:

{{
  ""onerilenPaket"": ""Premium | Standart | Ekonomik"",
  ""ikinciSecenek"": ""Premium | Standart | Ekonomik"",
  ""neden"": ""Kısa analiz metni""
}}
";

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _openAiApiKey);

            var body = new
            {
                model = "gpt-4.1-mini",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            dynamic ai = JsonConvert.DeserializeObject(jsonResponse);
            string aiResult = ai.choices[0].message.content;

            // AI cevabı JSON formatında gelmiş olacak
            var result = JsonConvert.DeserializeObject<AIInsuranceRecommendationViewModel>(aiResult);

            // Sonuçları modele geri yazıyoruz
            model.RecommendedPackage = result.onerilenPaket;
            model.SecondBestPackage = result.ikinciSecenek;
            model.AnalysisText = result.neden;

            TempData["RawAI"] = aiResult;

            return View(model);
        }
    }
}
