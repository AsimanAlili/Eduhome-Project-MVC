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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index(int page=1,int? categoryId=null)
        {
            double totalCount =  _context.Courses.Where(x => (categoryId != null ? x.CategoryId == categoryId : true)).Count();
            int pageCount = (int)Math.Ceiling(totalCount / 9);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;
            CourseDetailViewModel courseVM = new CourseDetailViewModel
            {
                Categories =  _context.Categories.ToList()
            };
            return View(courseVM);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Course course = await _context.Courses
                .Include(x => x.Category)
                .Include(x => x.CourseTags).ThenInclude(x => x.Tag)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (course == null)
                return NotFound();

            CourseDetailViewModel courseVM = new CourseDetailViewModel
            {
                Course = course,
                Categories= await _context.Categories.ToListAsync(),
                Courses= await _context.Courses
                .Include(x => x.Category)
                .Include(x => x.CourseTags).ThenInclude(x => x.Tag).ToListAsync()

            };

            return View(courseVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Review(CourseReview review)
        {
            Course course = await _context.Courses.Include(x => x.CourseReviews).FirstOrDefaultAsync(x => x.Id == review.CourseId);

            if (course == null)
                return NotFound();


            CourseReview courseReview = new CourseReview
            {
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                Email = review.Email,
                FullName = review.FullName,
                CourseId = review.CourseId,
                Subject=review.Subject,
                Message = review.Message
            };

            course.CourseReviews.Add(courseReview);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        public IActionResult Search(string search)
        {
            var model = _context.Courses.Where(c => c.Name.Contains(search)).OrderByDescending(c => c.Id).Take(10).ToList();
            return PartialView("_SearchCoursePartial", model);
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
