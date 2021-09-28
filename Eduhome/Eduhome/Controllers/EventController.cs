using Eduhome.Data;
using Eduhome.Data.Entities;
using Eduhome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int? categoryId = null)
        {
            double totalCount = _context.Events.Where(x => (categoryId != null ? x.CategoryId == categoryId : true)).Count();
            int pageCount = (int)Math.Ceiling(totalCount / 9);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;
            ViewBag.CategoryId = categoryId;
            EventDetailViewModel eventVM = new EventDetailViewModel
            {
                Categories = _context.Categories.ToList()
            };
            return View(eventVM);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Event eventModel = await _context.Events
                .Include(x => x.Category)
                .Include(x => x.EventTags).ThenInclude(x => x.Tag)
                .Include(x => x.EventTeachers).ThenInclude(x => x.Teacher)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (eventModel == null)
                return NotFound();

            EventDetailViewModel eventVM = new EventDetailViewModel
            {
                Event = eventModel,
                Categories = await _context.Categories.ToListAsync(),
                Events = await _context.Events
                .Include(x => x.Category)
                .Include(x => x.EventTags).ThenInclude(x => x.Tag)
                .Include(x => x.EventTeachers).ThenInclude(x => x.Teacher)
                .ToListAsync()


            };

            return View(eventVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Review(EventReview review)
        {
            Event eventModel = await _context.Events.Include(x => x.EventReviews).FirstOrDefaultAsync(x => x.Id == review.EventId);

            if (eventModel == null)
                return NotFound();


            EventReview eventReview = new EventReview
            {
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                Email = review.Email,
                FullName = review.FullName,
                EventId = review.EventId,
                Subject = review.Subject,
                Message = review.Message
            };

            eventModel.EventReviews.Add(eventReview);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        public IActionResult Search(string search)
        {
            var model = _context.Events.Where(e => e.Title.ToLower().Contains(search.ToLower())).OrderByDescending(e => e.Id).Take(10).ToList();
            return PartialView("_SearchEventPartial", model);
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
