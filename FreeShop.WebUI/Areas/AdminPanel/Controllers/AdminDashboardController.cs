using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeShop.WebUI.ActionFilters;

namespace FreeShop.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboardController

        [ActiveManager]
        public ActionResult Index()
        {
            return View();
        }
    }
}
