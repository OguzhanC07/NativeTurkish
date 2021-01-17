using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NativeTurkish.Web.ApiServices.Interfaces;
using NativeTurkish.Web.CustomFilters;
using NativeTurkish.Web.Models;
using System.Threading.Tasks;

namespace NativeTurkish.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _contextAccessor;
        public HomeController(IHttpContextAccessor contextAccessor,IAuthService authService)
        {
            _authService = authService;
            _contextAccessor = contextAccessor;
        }

        [LoginFilter]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterLoginModel registerModel)
        {
            if (ModelState.IsValid)
            {
                string message = await _authService.SignUp(registerModel.AppUserRegisterModel);
                if (message=="")
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    TempData["LoginError"] = message;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(registerModel);
        }


        [HttpPost]
        public async Task<IActionResult> LogIn(RegisterLoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                string message = await _authService.SignIn(loginModel.AppUserLoginModel);
                if (message == "")
                {
                    string role = _contextAccessor.HttpContext.Session.GetString("role");
                    if (role.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { @area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { @area = "Member" });
                    }
                }
                else
                {
                    TempData["LoginError"] = message;
                    return RedirectToAction("Index","Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}