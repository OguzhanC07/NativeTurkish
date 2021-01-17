using Microsoft.AspNetCore.Mvc;
using NativeTurkish.Web.ApiServices.Interfaces;
using NativeTurkish.Web.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [JwtAuthorize(Roles = "Admin,Member")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetQuestion(string level)
        {
            var message = await _questionService.GetQuestionByLevel("A1");
            return View();
        }
    }
}
