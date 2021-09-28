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
    [Area("Manage")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]

    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TestimonialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Testimonials.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            TestimonalViewModel testimonialVM = new TestimonalViewModel
            {
                Testimonials = await _context.Testimonials.Skip((page - 1) * 5).Take(5).ToListAsync()
            };

            return View(testimonialVM);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimonial testimonial)
        {
            #region ModelStateCheck
            if (!ModelState.IsValid)
            {
                return View(testimonial);
            }
            #endregion

            if (testimonial.File != null)
            {
                #region CheckPhotoLength
                if (testimonial.File.Length > 4 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 4MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (testimonial.File.ContentType != "image/png" && testimonial.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManager.Save(_env.WebRootPath, "uploads/testimonials", testimonial.File);

                testimonial.Photo = filename;
            }
            testimonial.CreatedAt = DateTime.UtcNow;
            testimonial.ModifiedAt = DateTime.UtcNow;

            await _context.Testimonials.AddAsync(testimonial);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Testimonial testimonial = await _context.Testimonials.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSlider

            if (testimonial == null)
            {
                return NotFound();
            }
            #endregion
            return View(testimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Testimonial testimonial)
        {
            Testimonial existTestimonial = await _context.Testimonials.FirstOrDefaultAsync(s => s.Id == testimonial.Id);

            #region CheckSlider

            if (existTestimonial == null)
            {
                return NotFound();
            }
            #endregion

            existTestimonial.FullName = testimonial.FullName;
            existTestimonial.Desc = testimonial.Desc;
            existTestimonial.Occupation = testimonial.Occupation;
            existTestimonial.Place = testimonial.Place;
            existTestimonial.ModifiedAt = DateTime.UtcNow;


            #region ModelStateCheck
            if (!ModelState.IsValid)
            {
                return View(testimonial);
            }
            #endregion

            if (testimonial.File != null)
            {
                #region CheckPhotoLength
                if (testimonial.File.Length > 4 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 4MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (testimonial.File.ContentType != "image/png" && testimonial.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManager.Save(_env.WebRootPath, "uploads/testimonials", testimonial.File);

                if (!string.IsNullOrWhiteSpace(existTestimonial.Photo))
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/sliders", existTestimonial.Photo);
                }

                existTestimonial.Photo = filename;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Detail(int id)
        {
            Testimonial testimonial = await _context.Testimonials.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSliderNotFound
            if (testimonial == null)
            {
                return NotFound();
            }
            #endregion

            return View(testimonial);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Testimonial testimonial = await _context.Testimonials.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSliderNotFound
            if (testimonial == null)
            {
                return NotFound();
            }
            #endregion

            return View(testimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Testimonial testimonialModel)
        {
            Testimonial testimonial = await _context.Testimonials.FirstOrDefaultAsync(s => s.Id == testimonialModel.Id);

            #region CheckSliderNotFound
            if (testimonial == null)
            {
                return NotFound();
            }
            #endregion


            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
