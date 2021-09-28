using Eduhome.Data;
using Eduhome.Data.Entities;
using Eduhome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? categoryId)
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders = _context.Sliders.OrderBy(x => x.Order).ToList(),
                Courses= _context.Courses.Where(x => (categoryId != null ? x.CategoryId == categoryId : true))
                .Include(x => x.Category)
                .Include(x => x.CourseTags).ThenInclude(x => x.Tag)
                .OrderByDescending(x => x.CreatedAt)
                .Take(3).ToList(),
                Teachers=_context.Teachers.Take(3).ToList(),
                Events= _context.Events.Where(x => (categoryId != null ? x.CategoryId == categoryId : true))
                .Include(x => x.Category)
                .Include(x => x.EventTags).ThenInclude(x => x.Tag)
                .Include(x => x.EventTeachers).ThenInclude(x => x.Teacher)
                .OrderByDescending(x => x.CreatedAt)
                .Take(4).ToList(),
                Testimonials=_context.Testimonials.ToList(),
                Notices=_context.Notices.OrderByDescending(x=>x.CreatedAt).ToList(),

            };
            return View(homeVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Subscribe(Subscribe subscribe)
        {
    
            Subscribe subModel = new Subscribe
            {
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                Email = subscribe.Email

            };

            _context.Subscribes.Add(subModel);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
