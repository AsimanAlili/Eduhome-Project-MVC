using Eduhome.Areas.Manage.ViewModels;
using Eduhome.Data;
using Eduhome.Data.Entities;
using Eduhome.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]

    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CourseController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            double totalCount = await _context.Courses.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;
            CourseViewModel courseVM = new CourseViewModel
            {
                Courses = await _context.Courses.Include(x => x.Category).Skip((page - 1) * 5).Take(5).ToListAsync()
            };

            return View(courseVM);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Course course)
        {

            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();

            if (await _context.Courses.AnyAsync(x => x.Slug.ToLower() == course.Slug.Trim().ToLower()))
            {
               
                ModelState.AddModelError("Slug", "Course already exist!");
                return View();
            }

            if (!await _context.Categories.AnyAsync(c => c.Id == course.CategoryId && !c.IsDeleted))
            {
                
                ModelState.AddModelError("CategoryId", "Category not found!");
                return View();
            }

            if (!ModelState.IsValid)
            {
               
                return View();
            }

            course.CourseTags = await _createCourseTags(course.TagIds);

            if (course.File != null)
            {
                #region CheckPhotoLength
                if (course.File.Length > 4 * (1024 * 1024))
                {
                   
                    ModelState.AddModelError("File", "Cannot be more than 4MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (course.File.ContentType != "image/png" && course.File.ContentType != "image/jpeg")
                {
                   
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManager.Save(_env.WebRootPath, "uploads/courses", course.File);

                course.Photo = filename;
            }
           
            course.CreatedAt = DateTime.UtcNow;
            course.ModifiedAt = DateTime.UtcNow;
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();


            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Course course = await _context.Courses
                .Include(x => x.CourseTags)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();

            return View(course);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Course course)
        {
            Course existCourse = await _context.Courses
                .Include(x => x.CourseTags)
                .FirstOrDefaultAsync(x => x.Id == course.Id);

            if (existCourse == null)
                return NotFound();

            if (!await _context.Categories.AnyAsync(x => x.Id == course.CategoryId))
                return NotFound();

            if (await _context.Courses.AnyAsync(x => x.Slug.ToLower() == course.Slug.Trim().ToLower() && x.Id != course.Id))
                return NotFound();

            existCourse.CourseTags = await _getUpdatedCourseTagsAsync(existCourse.CourseTags, course.TagIds, course.Id);

            if (course.File != null)
            {
                #region CheckPhotoLength
                if (course.File.Length > 4 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 4MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (course.File.ContentType != "image/png" && course.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManager.Save(_env.WebRootPath, "uploads/courses", course.File);

                if (!string.IsNullOrWhiteSpace(existCourse.Photo))
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/courses", existCourse.Photo);
                }

                existCourse.Photo = filename;
            }

            existCourse.Name = course.Name.Trim();
            existCourse.Slug = course.Slug.Trim();
            existCourse.Desc = course.Desc;
            existCourse.AboutDesc = course.AboutDesc;
            existCourse.ApplyDesc = course.ApplyDesc;
            existCourse.CertificationDesc = course.CertificationDesc;
            existCourse.CategoryId = course.CategoryId;
            existCourse.Price = course.Price;
            existCourse.Start = course.Start;
            existCourse.Duration = course.Duration;
            existCourse.Hours = course.Hours;
            existCourse.SkillLevel = course.SkillLevel;
            existCourse.Student = course.Student;
            existCourse.Language = course.Language;
            existCourse.ModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Course course)
        {
            Course existcourse = await _context.Courses.FirstOrDefaultAsync(x => x.Id == course.Id);

            if (existcourse == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(existcourse);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSliderNotFound
            if (course == null)
            {
                return NotFound();
            }
            #endregion
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            return View(course);
        }
        public async Task<IActionResult> Review(int courseId)
        {
            List<CourseReview> courseReviews = await _context.CourseReviews.Where(x => x.CourseId == courseId).ToListAsync();

            return View(courseReviews);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteReview(int id)
        {
            CourseReview review = await _context.CourseReviews.FirstOrDefaultAsync(x => x.Id == id);
            Course course = await _context.Courses.Include(x => x.CourseReviews).FirstOrDefaultAsync(x => x.Id == review.CourseId);


            if (review == null)
                return NotFound();

            _context.CourseReviews.Remove(review);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        #region CreateCourseTags
        private async Task<List<CourseTag>> _createCourseTags(int[] tagIds)
        {

            List<CourseTag> courseTags = new List<CourseTag>();
            foreach (var tagId in tagIds)
            {
                if (!await _context.Tags.AnyAsync(x => x.Id == tagId))
                {
                    throw new Exception("Tag not found!");
                }

                CourseTag courseTag = new CourseTag
                {
                    TagId = tagId
                };

                courseTags.Add(courseTag);
            }

            return courseTags;
        }

        #endregion

        #region UpdatedCourseTags
        private async Task<List<CourseTag>> _getUpdatedCourseTagsAsync(List<CourseTag> courseTags, int[] tagIds, int courseId)
        {
            List<CourseTag> removableTags = new List<CourseTag>();
            removableTags.AddRange(courseTags);

            foreach (var tagId in tagIds)
            {
                CourseTag tag = courseTags.FirstOrDefault(x => x.TagId == tagId);

                if (tag != null)
                {
                    removableTags.Remove(tag);
                }
                else
                {
                    if (!await _context.Tags.AnyAsync(x => x.Id == tagId))
                    {
                        throw new Exception("Tag not found!");
                    }

                    tag = new CourseTag
                    {
                        TagId = tagId,
                        CourseId = courseId
                    };

                    courseTags.Add(tag);
                }
            }

            courseTags = courseTags.Except(removableTags).ToList();

            return courseTags;
        }

        #endregion

    }
}
