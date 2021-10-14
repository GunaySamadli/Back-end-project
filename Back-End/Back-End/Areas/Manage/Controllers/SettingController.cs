using Back_End.Helpers;
using Back_End.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
       
        public IActionResult Edit()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            return View(setting);
        }

        [HttpPost]
        public IActionResult Edit(Setting setting)
        {
            Setting existSetting = _context.Settings.FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (setting.HeaderImgFile != null)
            {

                if (setting.HeaderImgFile.ContentType != "image/png" && setting.HeaderImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (setting.HeaderImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                if (existSetting.HeaderLogo != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.HeaderLogo);
                }

                string newFileName = FileManager.Save(_env.WebRootPath, "uploads/setting", setting.HeaderImgFile);
                existSetting.HeaderLogo = newFileName;

            }

            if (setting.AboutImgFile != null)
            {

                if (setting.AboutImgFile.ContentType != "image/png" && setting.AboutImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (setting.AboutImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                if (existSetting.AboutImage != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.AboutImage);
                }

                string newFileName = FileManager.Save(_env.WebRootPath, "uploads/setting", setting.AboutImgFile);
                existSetting.AboutImage = newFileName;

            }

            if (setting.FooterImgFile != null)
            {

                if (setting.FooterImgFile.ContentType != "image/png" && setting.FooterImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (setting.FooterImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                if (existSetting.FooterLogo != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.FooterLogo);
                }

                string newFileName = FileManager.Save(_env.WebRootPath, "uploads/setting", setting.FooterImgFile);
                existSetting.FooterLogo = newFileName;

            }

            if (setting.ServiceImgFile != null)
            {

                if (setting.ServiceImgFile.ContentType != "image/png" && setting.ServiceImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (setting.ServiceImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                if (existSetting.ServiceImage != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.ServiceImage);
                }

                string newFileName = FileManager.Save(_env.WebRootPath, "uploads/setting", setting.ServiceImgFile);
                existSetting.ServiceImage = newFileName;

            }

            if (setting.VideoFile != null)
            {

                if (setting.VideoFile.ContentType != "image/png" && setting.VideoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (setting.VideoFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }
                if (existSetting.HomePageImg != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.HomePageImg);
                }

                string newFileName = FileManager.Save(_env.WebRootPath, "uploads/setting", setting.VideoFile);
                existSetting.HomePageImg = newFileName;

            }


            existSetting.AboutDesc = setting.AboutDesc;
            existSetting.AboutTitle = setting.AboutTitle;
            existSetting.AboutUrl = setting.AboutUrl;
            existSetting.AboutUrlText = setting.AboutUrlText;
            existSetting.Adress = setting.Adress;
            existSetting.ContactMail = setting.ContactMail;
            existSetting.CopyRight = setting.CopyRight;
            existSetting.DribbleUrl = setting.DribbleUrl;
            existSetting.FbUrl = setting.FbUrl;
            existSetting.FooterDesc = setting.FooterDesc;
            existSetting.InstaUrl = setting.InstaUrl;
            existSetting.Phone = setting.Phone;
            existSetting.SupportMail = setting.SupportMail;
            existSetting.TwitterUrl = setting.TwitterUrl;

            _context.SaveChanges();


            return RedirectToAction("index","dashboard");
        }
    }
}
