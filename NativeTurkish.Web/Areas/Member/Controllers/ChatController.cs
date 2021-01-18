using Microsoft.AspNetCore.Mvc;
using NativeTurkish.Web.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [JwtAuthorize(Roles ="Admin,Member")]
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
