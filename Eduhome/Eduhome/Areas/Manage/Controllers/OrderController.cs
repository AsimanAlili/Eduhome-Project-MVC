using Eduhome.Data;
using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Authorization;
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
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Order> orders = await _context.Orders.Include(x => x.Course).Include(x => x.AppUser).ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Order order = await _context.Orders
                .Include(x => x.AppUser)
                .Include(x => x.Course)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound();

            order.Status = Data.Enum.OrderStatus.Accepted;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound();

            order.Status = Data.Enum.OrderStatus.Rejected;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
