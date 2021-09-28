using Eduhome.Data;
using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Areas.Manage.Controllers
{
    [Area("manage")]

    public class SubscribeController : Controller
    {
        private AppDbContext _context;

        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Subscribe> subscribes = await _context.Subscribes.ToListAsync();

            return View(subscribes);
        }
    }
}
