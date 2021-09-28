using Eduhome.Areas.Manage.ViewModels;
using Eduhome.Data;
using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eduhome.Areas.Manage.Controllers
{
    [Area("manage")]

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser admin = await _userManager.FindByNameAsync(loginVM.UserName);
            #region CheckAdmin
            if (admin == null)
            {
                ModelState.AddModelError("", "User or Password is incorrect!");
                return View();
            }

            #endregion

            #region CheckPassword
            if (!await _userManager.CheckPasswordAsync(admin,loginVM.Password))
            {
                ModelState.AddModelError("", "User or Password is incorrect!");
                return View();
            }
            #endregion

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,admin.Id),
                new Claim(ClaimTypes.Name,admin.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            },"Admin_Auth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Admin_Auth", claimsPrincipal);

            return RedirectToAction("index", "dashboard");

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Admin_Auth");

            return RedirectToAction("login", "account");
        }


        [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
        public async Task<IActionResult> Profile()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
        public async Task<IActionResult> Profile(AppUser user)
        {
            AppUser existUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (existUser == null)
                return NotFound();


            if (_context.Users.Any(u => u.FullName == user.FullName && u.Id != existUser.Id))
            {
                ModelState.AddModelError("FullName", "FullName already used");
                return View();
            }

            existUser.FullName = user.FullName;

            if (!string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.CurrentPassword) && !string.IsNullOrWhiteSpace(user.ConfirmPassword))
            {
                var resultPass = await _userManager.ChangePasswordAsync(existUser, user.CurrentPassword, user.Password);
                if (!resultPass.Succeeded)
                {
                    ModelState.AddModelError("CurrentPassword", "Password incorrect!");
                    return View();
                }
            }

            await _userManager.UpdateAsync(existUser);

            return RedirectToAction("index", "home");
        }




        //public async Task Create()
        //{
        //    AppUser user = new AppUser
        //    {
        //        UserName = "SuperAdmin",
        //        FullName = "Super Admin",
        //    };

        //    await _userManager.CreateAsync(user, "Admin123");
        //    await _userManager.AddToRoleAsync(user, "Admin");

        //}


        //public async Task CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //}
    }
}
