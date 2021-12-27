using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeShop.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace FreeShop.WebUI.Areas.AdminPanel.Components
{
    public class LayoutSideBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string adminSession = HttpContext.Session.GetString("ActiveManager");
            Manager adminSessionModel;

            if (!string.IsNullOrEmpty(adminSession))
            {
                adminSessionModel = JsonConvert.DeserializeObject<Manager>(adminSession);
            }
            else
            {
                adminSessionModel = null;
            }

            return View(adminSessionModel);
        }
    }
}
