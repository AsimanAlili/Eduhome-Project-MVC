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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            double totalCount = _context.Teachers.Count();
            int pageCount = (int)Math.Ceiling(totalCount / 9);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;
          
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            if (teacher == null)
                return NotFound();

            TeacherDetailViewModel teacherVM = new TeacherDetailViewModel
            {
                Teacher = teacher 
            };

            return View(teacherVM);
        }
        public IActionResult Search(string search)
        {
            var model = _context.Teachers.Where(t => t.FullName.Contains(search)).OrderByDescending(t => t.Id).Take(5).ToList();
            return PartialView("_SearchTeacherPartial", model);
        }

       
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Subscribe(Subscribe subscribe)
        {


            Subscribe sub = new Subscribe
            {
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                Email = subscribe.Email

            };

            _context.Subscribes.Add(sub);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
