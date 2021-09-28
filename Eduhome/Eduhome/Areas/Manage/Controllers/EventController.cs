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

    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Events.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;
            EventViewModel eventVM = new EventViewModel
            {
                Events = await _context.Events.Include(x => x.Category).Skip((page - 1) * 5).Take(5).ToListAsync()
            };

            return View(eventVM);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Event eventModel)
        {

            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();


            if (await _context.Events.AnyAsync(x => x.Title.ToLower() == eventModel.Title.Trim().ToLower()))
            {

                ModelState.AddModelError("Title", "Event already exist!");
                return View();
            }

            if (!await _context.Categories.AnyAsync(c => c.Id == eventModel.CategoryId && !c.IsDeleted))
            {

                ModelState.AddModelError("CategoryId", "Category not found!");
                return View();
            }

            if (!ModelState.IsValid)
            {

                return View();
            }

            eventModel.EventTags = await _createEventTags(eventModel.TagIds);
            eventModel.EventTeachers = await _createEventTeachers(eventModel.TeacherIds);

            if (eventModel.File != null)
            {
                #region CheckPhotoLength
                if (eventModel.File.Length > 4 * (1024 * 1024))
                {

                    ModelState.AddModelError("File", "Cannot be more than 4MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (eventModel.File.ContentType != "image/png" && eventModel.File.ContentType != "image/jpeg")
                {

                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManager.Save(_env.WebRootPath, "uploads/events", eventModel.File);

                eventModel.Photo = filename;
            }

            eventModel.CreatedAt = DateTime.UtcNow;
            eventModel.ModifiedAt = DateTime.UtcNow;
            await _context.Events.AddAsync(eventModel);
            await _context.SaveChangesAsync();


            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Event eventModel = await _context.Events
                .Include(x => x.EventTags)
                .Include(x => x.EventTeachers)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (eventModel == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();


            return View(eventModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Event eventModel)
        {
            Event existEvent = await _context.Events
                .Include(x => x.EventTags)
                .Include(x => x.EventTeachers)
                .FirstOrDefaultAsync(x => x.Id == eventModel.Id);

            if (existEvent == null)
                return NotFound();

            if (!await _context.Categories.AnyAsync(x => x.Id == eventModel.CategoryId))
                return NotFound();

            if (await _context.Events.AnyAsync(x => x.Title.ToLower() == eventModel.Title.Trim().ToLower() && x.Id != eventModel.Id))
                return NotFound();

            existEvent.EventTags = await _getUpdatedEventTagsAsync(existEvent.EventTags, eventModel.TagIds, eventModel.Id);
            existEvent.EventTeachers = await _getUpdatedEventTeachersAsync(existEvent.EventTeachers, eventModel.TeacherIds, eventModel.Id);

            if (eventModel.File != null)
            {
                #region CheckPhotoLength
                if (eventModel.File.Length > 4 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 4MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (eventModel.File.ContentType != "image/png" && eventModel.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManager.Save(_env.WebRootPath, "uploads/events", eventModel.File);

                if (!string.IsNullOrWhiteSpace(existEvent.Photo))
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/events", existEvent.Photo);
                }

                existEvent.Photo = filename;
            }

            existEvent.Title = eventModel.Title.Trim();
            existEvent.Desc = eventModel.Desc;
            existEvent.Venue = eventModel.Venue;
            existEvent.Date = eventModel.Date;
            existEvent.StartTime = eventModel.StartTime;
            existEvent.EndTime = eventModel.EndTime;
            existEvent.ModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            Event eventModel = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);

            if (eventModel == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();


            return View(eventModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Event eventModel)
        {
            Event existEvent = await _context.Events.FirstOrDefaultAsync(x => x.Id == eventModel.Id);

            if (existEvent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(existEvent);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Detail(int id)
        {
            Event eventModel = await _context.Events.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSliderNotFound
            if (eventModel == null)
            {
                return NotFound();
            }
            #endregion
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Teachers = await _context.Teachers.ToListAsync();

            return View(eventModel);
        }
        public async Task<IActionResult> Review(int eventId)
        {
            List<EventReview> eventReviews = await _context.EventReviews.Where(x => x.EventId == eventId).ToListAsync();

            return View(eventReviews);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteReview(int id)
        {
            EventReview review = await _context.EventReviews.FirstOrDefaultAsync(x => x.Id == id);
            Event eventModel = await _context.Events.Include(x => x.EventReviews).FirstOrDefaultAsync(x => x.Id == review.EventId);


            if (review == null)
                return NotFound();

            _context.EventReviews.Remove(review);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        #region CreateEventTags
        private async Task<List<EventTag>> _createEventTags(int[] tagIds)
        {

            List<EventTag> eventTags = new List<EventTag>();
            foreach (var tagId in tagIds)
            {
                if (!await _context.Tags.AnyAsync(x => x.Id == tagId))
                {
                    throw new Exception("Tag not found!");
                }

                EventTag eventTag = new EventTag
                {
                    TagId = tagId
                };

                eventTags.Add(eventTag);
            }

            return eventTags;
        }

        #endregion

        #region CreateEventTeachers
        private async Task<List<EventTeacher>> _createEventTeachers(int[] teacherIds)
        {

            List<EventTeacher> eventTeachers = new List<EventTeacher>();
            foreach (var teacherId in teacherIds)
            {
                if (!await _context.Teachers.AnyAsync(x => x.Id == teacherId))
                {
                    throw new Exception("Teacher not found!");
                }

                EventTeacher eventTeacher = new EventTeacher
                {
                    TeacherId = teacherId
                };

                eventTeachers.Add(eventTeacher);
            }

            return eventTeachers;
        }

        #endregion

        #region UpdatedEventTags
        private async Task<List<EventTag>> _getUpdatedEventTagsAsync(List<EventTag> eventTags, int[] tagIds, int eventId)
        {
            List<EventTag> removableTags = new List<EventTag>();
            removableTags.AddRange(eventTags);

            foreach (var tagId in tagIds)
            {
                EventTag tag = eventTags.FirstOrDefault(x => x.TagId == tagId);

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

                    tag = new EventTag
                    {
                        TagId = tagId,
                        EventId = eventId
                    };

                    eventTags.Add(tag);
                }
            }

            eventTags = eventTags.Except(removableTags).ToList();

            return eventTags;
        }

        #endregion

        #region UpdatedEventTeachers
        private async Task<List<EventTeacher>> _getUpdatedEventTeachersAsync(List<EventTeacher> eventTeachers, int[] teacherIds, int eventId)
        {
            List<EventTeacher> removableTeachers = new List<EventTeacher>();
            removableTeachers.AddRange(eventTeachers);

            foreach (var teacherId in teacherIds)
            {
                EventTeacher teacher = eventTeachers.FirstOrDefault(x => x.TeacherId == teacherId);

                if (teacher != null)
                {
                    removableTeachers.Remove(teacher);
                }
                else
                {
                    if (!await _context.Teachers.AnyAsync(x => x.Id == teacherId))
                    {
                        throw new Exception("Teacher not found!");
                    }

                    teacher = new EventTeacher
                    {
                        TeacherId = teacherId,
                        EventId = eventId
                    };

                    eventTeachers.Add(teacher);
                }
            }

            eventTeachers = eventTeachers.Except(removableTeachers).ToList();

            return eventTeachers;
        }

        #endregion
    }
}
