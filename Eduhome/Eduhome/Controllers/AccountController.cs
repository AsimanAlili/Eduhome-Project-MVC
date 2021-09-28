using Eduhome.Data;
using Eduhome.Data.Entities;
using Eduhome.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eduhome.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginViewModel loginVM)
        {
            #region CheckModelState
            if (!ModelState.IsValid)
            {
                return View();
            }
            #endregion

            AppUser member = await _userManager.FindByEmailAsync(loginVM.Email);
            #region CheckMemberEmail
            if (member==null)
            {
                ModelState.AddModelError("", "Email or Password is Incorrect");
                return View();
            }
            #endregion
            #region CheckMemberPassword
            if (!await _userManager.CheckPasswordAsync(member,loginVM.Password))
            {
                ModelState.AddModelError("", "Email or Password is Incorrect");
                return View();
            }
            #endregion
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,member.Id),
                new Claim(ClaimTypes.Name,member.UserName),
                new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.Role,"Member")
            }, "Member_Auth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("Member_Auth", claimsPrincipal);

            return RedirectToAction("index", "home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(MemberRegisterViewModel registerVM)
        {
            #region CheckModelState
            if (!ModelState.IsValid)
            {
                return View();
            }
            #endregion

            AppUser member = await _userManager.FindByEmailAsync(registerVM.Email);

            #region CheckMemberEmailAndUserName

            if (member != null)
            {
                ModelState.AddModelError("", "Email already used");
                return View();
            }
            else
            {
                member = await _userManager.FindByNameAsync(registerVM.UserName);

                if (member != null)
                {
                    ModelState.AddModelError("", "Username already used");
                    return View();
                }
            }
            #endregion

            member = new AppUser
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                FullName = registerVM.FullName
            };

            var result = await _userManager.CreateAsync(member, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(member, "Member");


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,member.UserName),
                new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.Role,"Member")
            }, "Member_Auth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Member_Auth", claimsPrincipal);

            return RedirectToAction("index", "home");

        }



        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Profile()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Profile(AppUser user)
        {
            AppUser existUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (existUser == null)
                return NotFound();


            if (_context.Users.Any(u => u.Email == user.Email && u.Id != existUser.Id))
            {
                ModelState.AddModelError("Email", "Email already used");
                return View();
            }

            existUser.Email = user.Email;
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


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Member_Auth");

            return RedirectToAction("index", "home");
        }
    }
}
