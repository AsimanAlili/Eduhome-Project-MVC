using Eduhome.Data;
using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.ViewComponents
{
    public class EventViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public EventViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int? categoryId = null)
        {
            List<Event> events = _context.Events
                .Where(x => (categoryId != null ? x.CategoryId == categoryId : true))
                .Include(x => x.Category)
                .Include(x => x.EventTags).ThenInclude(x => x.Tag)
                .Include(x => x.EventTeachers).ThenInclude(x => x.Teacher)
                .OrderByDescending(x => x.CreatedAt)
                .Skip((page - 1) * 9).Take(9).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", events));
        }
    }
}
