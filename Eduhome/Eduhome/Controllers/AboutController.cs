using Eduhome.Data;
using Eduhome.Data.Entities;
using Eduhome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutViewModel aboutVM = new AboutViewModel
            {
                Testimonials = _context.Testimonials.OrderBy(x => x.CreatedAt).ToList(),
                Teachers= _context.Teachers.OrderByDescending(x=>x.CreatedAt).Take(4).ToList(),
                Notices = _context.Notices.OrderByDescending(x => x.CreatedAt).ToList(),


            };
            return View(aboutVM);
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
