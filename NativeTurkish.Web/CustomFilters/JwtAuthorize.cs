using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.CustomFilters
{
    public class JwtAuthorize : ActionFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("token");

            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }

            bool accessStatus = false;

            var userRoles = context.HttpContext.Session.GetString("role");

            if (!string.IsNullOrWhiteSpace(userRoles))
            {
                if (!string.IsNullOrWhiteSpace(Roles))
                {
                    if (Roles.Contains(","))
                    {
                        var acceptedRoles = Roles.Split(",");
                        foreach (var role in acceptedRoles)
                        {
                            if (userRoles.Contains(role))
                            {
                                accessStatus = true;
                            }
                        }
                    }
                    else
                    {
                        if (userRoles.Contains(Roles))
                        {
                            accessStatus = true;
                        }
                    }

                    if (!accessStatus)
                    {
                        context.Result = new RedirectToActionResult("AccessDenied", "Auth", null);
                    }
                }
                else
                {
                    context.HttpContext.Session.Remove("token");
                    context.HttpContext.Session.Remove("roles");
                    context.Result = new RedirectToActionResult("Index", "Home", null);
                }
            }
            else
            {
                context.HttpContext.Session.Remove("token");
                context.HttpContext.Session.Remove("roles");
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
