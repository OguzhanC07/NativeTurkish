using Microsoft.AspNetCore.Mvc;
using NativeTurkish.Web.ApiServices.Interfaces;
using NativeTurkish.Web.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.Areas.Admin.Controllers
{
    [JwtAuthorize(Roles="Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async  Task<IActionResult> Index()
        {
            var data = await _userService.GetAllUsersAsync();
            if (data==null)
            {
                return View();
            }
            else
            {
                return View(data);
            }
        }
    }
}
