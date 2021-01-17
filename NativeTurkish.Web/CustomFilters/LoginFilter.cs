using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.CustomFilters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string token = context.HttpContext.Session.GetString("token");
            string role = context.HttpContext.Session.GetString("role");
            if (token=="" || role=="")
            {
                context.Result = new ViewResult();
            }
            else
            {
                if (context.HttpContext.Session.GetString("role")==null)
                {
                    context.HttpContext.Session.Remove("token");
                    context.HttpContext.Session.Remove("id");

                    context.Result = new ViewResult();
                }
                else
                {
                    if (role.Contains("Admin"))
                    {
                        context.Result = new RedirectToActionResult("Index", "Home", new { @Area = "Admin" });
                    }
                    else
                    {
                        context.Result = new RedirectToActionResult("Index", "Home", new { @Area = "Member" });
                    }
                }
            }
        }
    }
}
