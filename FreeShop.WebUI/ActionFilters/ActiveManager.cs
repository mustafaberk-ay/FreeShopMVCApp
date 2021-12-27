using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeShop.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace FreeShop.WebUI.ActionFilters
{
    public class ActiveManager : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            string adminSession = context.HttpContext.Session.GetString("ActiveManager");
            Manager adminSessionModel;

            if (!string.IsNullOrEmpty(adminSession))
            {
                adminSessionModel = JsonConvert.DeserializeObject<Manager>(adminSession);
            }
            else
            {
                adminSessionModel = null;
            }

            if (adminSession!=null)
                return;

            context.Result = new RedirectResult("/admin");
        }
    }
}
