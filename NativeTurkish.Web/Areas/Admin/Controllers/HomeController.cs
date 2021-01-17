using Microsoft.AspNetCore.Mvc;
using NativeTurkish.Web.CustomFilters;

namespace NativeTurkish.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [JwtAuthorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}