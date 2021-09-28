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
    [Area("manage")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]

    public class SettingController : Controller
    {
        private AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            SettingViewModel settingVM = new SettingViewModel
            {
                Setting=_context.Settings.FirstOrDefault()
            };
            return View(settingVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSlider

            if (setting == null)
            {
                return NotFound();
            }
            #endregion
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Setting setting)
        {
            Setting existSetting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == setting.Id);

            #region CheckSlider

            if (existSetting == null)
            {
                return NotFound();
            }
            #endregion

            existSetting.Title = setting.Title;
            existSetting.Phone = setting.Phone;
            existSetting.FooterDesc = setting.FooterDesc;
            existSetting.ServicePhone = setting.ServicePhone;
            existSetting.Address = setting.Address;
            existSetting.Email = setting.Email;
            existSetting.WebSiteUrl = setting.WebSiteUrl;
            existSetting.FacebookUrl = setting.FacebookUrl;
            existSetting.TwitterUrl = setting.TwitterUrl;
            existSetting.VimeoUrl = setting.VimeoUrl;
            existSetting.PinteresUrl = setting.PinteresUrl;
            existSetting.AboutTitle = setting.AboutTitle;
            existSetting.AboutDesc = setting.AboutDesc;
           


            #region ModelStateCheck
            if (!ModelState.IsValid)
            {
                return View(setting);
            }
            #endregion


           
            if (setting.LogoFile != null || setting.FooterLogoFile != null || setting.AboutFile != null)
            {

                if (setting.LogoFile!=null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.Logo);
                    setting.Files.Add(setting.LogoFile);

                }
               
                if (setting.FooterLogoFile != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.FooterLogo);
                    setting.Files.Add(setting.FooterLogoFile);

                }
               
                if (setting.AboutFile != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.AboutPhoto);
                    setting.Files.Add(setting.AboutFile);

                }
               

                foreach (var file in setting.Files)
                {
                    #region CheckPhotoLength
                    if (file.Length > 4 * (1024 * 1024))
                    {
                        ModelState.AddModelError("File", "Cannot be more than 4MB");
                        return View();

                    }
                    #endregion
                    #region CheckPhotoContentType
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("File", "Only jpeg and png files accepted");
                        return View();
                    }
                    #endregion
                    if (setting.LogoFile!=null)
                    {
                        if (file.Name.Trim().ToLower() == setting.LogoFile.Name.Trim().ToLower())
                        {
                            string filename = FileManager.Save(_env.WebRootPath, "uploads/setting", file);
                            existSetting.Logo = filename;
                        }
                    }
                    if (setting.FooterLogoFile != null)
                    {
                        if (file.Name.Trim().ToLower() == setting.FooterLogoFile.Name.Trim().ToLower())
                        {
                            string fileName = FileManager.Save(_env.WebRootPath, "uploads/setting", file);
                            existSetting.FooterLogo = fileName;
                        }
                    }

                    if (setting.AboutFile != null)
                    {
                        if (file.Name.Trim().ToLower() == setting.AboutFile.Name.Trim().ToLower())
                        {
                            string fileName = FileManager.Save(_env.WebRootPath, "uploads/setting", file);
                            existSetting.AboutPhoto = fileName;
                        }
                    }


                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
