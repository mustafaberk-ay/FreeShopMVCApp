using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FreeShop.Business.Abstract;
using FreeShop.Entities.Concrete;
using FreeShop.WebUI.Helpers;
using FreeShop.WebUI.ViewModels;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;

namespace FreeShop.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AdminController : Controller
    {
        private readonly IManagerService _managerService;

        public AdminController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            string usernameCK = Request.Cookies["Username_CK"];
            string passwordCK = Request.Cookies["Password_CK"];

            if (!string.IsNullOrEmpty(usernameCK) && !string.IsNullOrEmpty(passwordCK))
            {
                ViewData["Username_CK"] = usernameCK;
                ViewData["Password_CK"] = passwordCK;
                ViewData["IsChecked"] = true;
            }
            else
            {
                ViewData["IsChecked"] = false;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminViewModel vm)
        {
            Manager manager = _managerService.Login(vm.Username, vm.Password);

            var errorMessage = "";

            if (!ModelState.IsValid)
            {
                foreach (var values in ModelState.Values)
                {
                    foreach (var errors in values.Errors)
                    {
                        errorMessage += errors.ErrorMessage + "<br>";
                    }
                }
                return Json(new { isOk = false, message = errorMessage });
            }


            if (manager != null)
            {
                if (vm.IsChecked)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(2);

                    Response.Cookies.Append("Username_CK", vm.Username, options);
                    Response.Cookies.Append("Password_CK", vm.Password, options);
                }
                else
                {
                    Response.Cookies.Delete("Username_CK");
                    Response.Cookies.Delete("Password_CK");
                }

                string jsonStr = JsonConvert.SerializeObject(manager);

                HttpContext.Session.SetString("ActiveManager", jsonStr);

                
                

                return Json(new {isOk = true, Message = "Islem Basarili"});
            }
            else
            {
                return Json(new { isOk = false, Message = "HATA" });
            }
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordVm vm)
        {
            Manager manager = _managerService.GetByEmail(vm.ManagerEmail);

            if (manager != null)
            {
                string message = $"Sayin {manager.FullName} Parolaniz: <br> {manager.Password}";
                MailHelper.Send(vm.ManagerEmail, "Sifreniz", message );
                return Json(new {isOk = true, message = "Sifreniz Gonderildi"});
            }
            else
            {
                return Json(new { isOk = false, message = "Kullanici Bulunamadi" });
            }
        }

        public IActionResult Index()
        {
            List<Manager> managers = _managerService.GetAll();

            return View(managers);
        }

        public IActionResult NewManager()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewManager(Manager vm)
        {
            _managerService.Insert(vm);
            return Json(new {isOk = true, message = "Yonetici kayit islemi basarili"});
        }

        [HttpPost]
        public IActionResult PhotoUpload()
        {
            IFormFileCollection files = Request.Form.Files;
            if (files.Count > 0)
            {
                var fileName = files[0].FileName;
                var contentType = files[0].ContentType; //MIME Type
                var length = files[0].Length;

                if (!contentType.StartsWith("image/"))
                {
                    return Json(new {isOk = false, message = "Lutfen bir resim dosyasi gonderin"});
                }

                var randomFileName = RandomNameGenerator.GenerateFileName(Path.GetExtension(fileName));
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/adminlte/images/ManagerPhotos/" + randomFileName);

                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    files[0].CopyTo(stream);
                }
                return Json(new { isOk = true, PhotoPath = "/adminlte/images/ManagerPhotos/" + randomFileName });   //AJAX

                //if (length > 1024 * 1024)
                //{
                //    return Json(new { isOk = false, message = "Lutfen maximum 1MB boyutunda dosya seciniz" });
                //}
            }
            else
            {
                return Json(new {isOk = false, message = "Lutfen bir resim yukleyin" });
            }
        }
    }
}
