using FreeShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FreeShop.Business.Abstract;

namespace FreeShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManagerService _managerService;

        public HomeController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public IActionResult Index()
        {
            _managerService.GetAll();
            return View();
        }
    }
}
