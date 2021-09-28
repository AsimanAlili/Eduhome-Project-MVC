using Eduhome.Data;
using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.ViewComponents
{
    public class TeacherViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public TeacherViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1)
        {
            List<Teacher> teachers = _context.Teachers.Skip((page - 1) * 12).Take(12).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", teachers));

        }
    }
}
