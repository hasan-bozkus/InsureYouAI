﻿using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCounterComponentPartial : ViewComponent
    {
        private readonly InsureContext _context;

        public _DefaultCounterComponentPartial(InsureContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.categoryCount = await _context.Categories.CountAsync();
            ViewBag.serviceCount = await _context.Sevices.CountAsync();
            ViewBag.userCount = await _context.Users.CountAsync();
            ViewBag.articleCount = await _context.Articles.CountAsync();
            return View();
        }
    }
}
