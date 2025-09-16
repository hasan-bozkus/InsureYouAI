using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace InsureYouAI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly InsureContext _context;

        public ArticleController(InsureContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _context.Articles.Include(x=> x.AppUser).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            article.CreatedDate = DateTime.Now;

            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteArticle(int id)
        {
            var result = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int id)
        {
            var value = await _context.Articles.FindAsync(id);
            value.CreatedDate = value.CreatedDate;
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArticle(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateArticleWithOpenAI()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticleWithOpenAI(string prompt)
        {
            //anahtar ezildi
            var apiKey = "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";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Sen bir sigorta şirketi için çalışan, içerik yazarlığı yapan bir yapay zekasın. Kullanıcının vereceği özet ve anahtar kelimelere göre sigortacılık sektörüyle ilgili bir makale üret. Makale en az 1000 kelime uzunluğunda olmalı, 1000 kelimenin altına düşmemelisin. Yeterli uzunlukta değilse yazmaya devam etmelisin. Giriş, gelişme ve sonuç bölümleri olmalı. Yazının sonunda yaklaşık kelime sayısını da belirt." },
                    new { role = "user", content = prompt }
                },
                temperature = 0.7
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                var content = result.choices[0].message.content;
                ViewBag.article = content;
            }
            else
            {
                ViewBag.article = "Bir hata oluştu!" + response.StatusCode;
            }

            return View();
        }

        public class OpenAIResponse
        {
            public List<Choice> choices { get; set; }
        }

        public class Choice
        {
            public Message message { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }
    }
}

//apiKey= "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";

//Sen bir sigorta şirketi için çalışan, içerik yazarlığı yapan bir yapay zekasın. 
//Kullanıcının vereceği özet ve anahtar kelimelere göre sigortacılık sektörüyle ilgili bir makale üret. 
//Makale en az 1000 kelime uzunluğunda olmalı, 1000 kelimenin altına düşmemelisin. 
//Yeterli uzunlukta değilse yazmaya devam etmelisin. 
//Giriş, gelişme ve sonuç bölümleri olmalı. 
//Yazının sonunda yaklaşık kelime sayısını da belirt.
//Sen bir sigorta şirketi için çalışan, içerik yazarlığı yapan bir yapay zekasın. Kullanıcının özet ve anahtar kelimelere göre sigortacılık sektörüyle ilgili makale üret. En az 1000 kelime olsun.