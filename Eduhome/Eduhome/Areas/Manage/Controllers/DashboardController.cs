using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Areas.Manage.Controllers
{
    public class DashboardController : Controller
    {
        [Area("manage")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
