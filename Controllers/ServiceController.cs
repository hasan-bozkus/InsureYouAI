﻿using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text.Json;

namespace InsureYouAI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly InsureContext _context;

        public ServiceController(InsureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _context.Sevices.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(Service message)
        {

            await _context.Sevices.AddAsync(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _context.Sevices.FindAsync(id);
            _context.Sevices.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _context.Sevices.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(Service message)
        {
            _context.Sevices.Update(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateServiceWithAntrophicClaude()
        {
            //anahtar ezildi
            string apiKey = "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";
            string prompt = "Bir sigorta şirketi için hizmetler bölümü hazırlamanı istiyorum. Burada 5 farklı hizmet olmalı. Bana maksimum 100 karakterden oluşan cümlelerle 5 tane hizmet içeriği yazar mısın?";

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.anthropic.com/");
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            client.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestBody = new
            {
                model = "claude-3-5-sonnet-20241022",
                max_tokens = 512,
                temperature = 0.5,
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody));
            var response = await client.PostAsync("v1/messages", jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.services = new List<string>
                {
                    $"Claued Api'den cevap alınamadı. Hata: {response.StatusCode}"
                };
                return View();
            }

            var responseString = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseString);

            var fullText = doc.RootElement.GetProperty("content")[0].GetProperty("text").GetString();

            var services = fullText.Split('\n').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.TrimStart('1', '2', '3', '4', '5', '.')).ToList();
            ViewBag.services = services;

            return View();
        }
    }
}
//apikey= "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";