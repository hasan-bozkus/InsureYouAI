using InsureYouAI.Context;
using InsureYouAI.Entities;
using InsureYouAI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers
{
    public class MessageController : Controller
    {
        private readonly InsureContext _context;
        private readonly AIService _aIService;

        public MessageController(InsureContext context, AIService aIService)
        {
            _context = context;
            _aIService = aIService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ControllerName = "Gelen Mesajlar";
            ViewBag.PageName = "İletişim Panelinden Gelen Mesaj Listesi";
            var values = await _context.Messages.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            var combinedText = $"{message.Subject} {message.MessageDetail}";
            var predictedCategory = await _aIService.PredictCategoryAsync(combinedText);

            var priority = await _aIService.PredictPriorityAsync(combinedText);

            message.Priority = priority;
            message.AICategory = predictedCategory;

            message.IsRead = false;
            message.SendDate = DateTime.UtcNow;

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var result = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMessage(int id)
        {
            var value = await _context.Messages.FindAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
