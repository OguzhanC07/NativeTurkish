using Microsoft.AspNetCore.Mvc;
using NativeTurkish.Web.ApiServices.Interfaces;
using NativeTurkish.Web.CustomFilters;
using NativeTurkish.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.Areas.Admin.Controllers
{
    [JwtAuthorize(Roles ="Admin")]
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _questionService.GetAllQuestions();
            if (data==null)
            {
                return View();
            }
            else
            {
                return View(data);
            }
        }


        public IActionResult AddQuestion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(QuestionAddModel model)
        {
            if (ModelState.IsValid)
            {
                await _questionService.AddAsync(model);
                return RedirectToAction("Index", "Question");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteQuestion(string id)
        {
            await _questionService.DeleteAsync(id);

            return RedirectToAction("Index","Question");
        }
    }
}
