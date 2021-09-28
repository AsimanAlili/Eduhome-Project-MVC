using Eduhome.Areas.Manage.ViewModels;
using Eduhome.Data;
using Eduhome.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Eduhome.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]

    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            double totalCount = await _context.Sliders.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            SliderViewModel sliderVM = new SliderViewModel
            {
                Sliders=await _context.Sliders.Skip((page-1)*5).Take(5).ToListAsync()
            };

            return View(sliderVM);
        }
        public async Task<IActionResult> Create()
        {
            Slider lastCategory = await _context.Sliders.OrderByDescending(c => c.Order).FirstOrDefaultAsync();

            if (lastCategory != null)
            {
                ViewBag.BiggestOrder = lastCategory.Order;
            }
            else
            {
                ViewBag.BiggestOrder = 0;
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {


            #region ModelStateCheck
            if (!ModelState.IsValid)
            {
                return View(slider);
            }
            #endregion

            if (slider.File != null)
            {
                #region CheckPhotoLength
                if (slider.File.Length > 4 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 4MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (slider.File.ContentType != "image/png" && slider.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManager.Save(_env.WebRootPath, "uploads/sliders", slider.File);

                slider.Photo = filename;
            }


            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");


        }

        public async Task<IActionResult> Edit(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSlider

            if (slider == null)
            {
                return NotFound();
            }
            #endregion
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Slider slider)
        {
            Slider existSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == slider.Id);

            #region CheckSlider

            if (existSlider == null)
            {
                return NotFound();
            }
            #endregion

            existSlider.Title = slider.Title;
            existSlider.Text = slider.Text;
            existSlider.RedirectUrl = slider.RedirectUrl;
            existSlider.ModifiedAt = DateTime.UtcNow;


            #region ModelStateCheck
            if (!ModelState.IsValid)
            {
                return View(slider);
            }
            #endregion

            if (slider.File != null)
            {
                #region CheckPhotoLength
                if (slider.File.Length > 4 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 4MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (slider.File.ContentType != "image/png" && slider.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManager.Save(_env.WebRootPath, "uploads/sliders", slider.File);

                if (!string.IsNullOrWhiteSpace(existSlider.Photo))
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/sliders", existSlider.Photo);
                }

                existSlider.Photo = filename;
            }


            await _context.SaveChangesAsync();

            return RedirectToAction("index");


        }

        public async Task<IActionResult> Detail(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSliderNotFound
            if (slider == null)
            {
                return NotFound();
            }
            #endregion

            return View(slider);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSliderNotFound
            if (slider == null)
            {
                return NotFound();
            }
            #endregion

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Slider sliderModel)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == sliderModel.Id);

            #region CheckSliderNotFound
            if (slider == null)
            {
                return NotFound();
            }
            #endregion


            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
