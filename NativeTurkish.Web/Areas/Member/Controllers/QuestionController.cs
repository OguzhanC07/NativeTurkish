using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NativeTurkish.Web.ApiServices.Interfaces;
using NativeTurkish.Web.CustomFilters;
using NativeTurkish.Web.Models;
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
        private readonly IHttpContextAccessor _accessor;
        public QuestionController(IHttpContextAccessor accessor, IQuestionService questionService)
        {
            _accessor = accessor;
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetLevel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetLevel(LevelModel model)
        {
            TempData["level"] = model.Level;
            return RedirectToAction("GetQuestion", "Question", new { @level = model.Level, @questionid = "" });
        }

        public async Task<IActionResult> GetQuestion([FromQuery] string level, [FromQuery] string questionid)
        {
            if (string.IsNullOrEmpty(level))
            {
                return RedirectToAction("Index", "Question");
            }
            else
            {
                if (string.IsNullOrEmpty(questionid))
                {
                    var question = await _questionService.GetQuestionByLevel(level, "");
                    return View(question);
                }
                else
                {
                    var question = await _questionService.GetQuestionByLevel(level, questionid);
                    return View(question);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetQuestion([FromQuery] string level, QuestionAnswerModel model)
        {
            var question = await _questionService.GetQuestionByIdAsync(model._id);
            foreach (var item in question.alternatives)
            {
                if (item.answer == model.answer && item.isCorrect == true)
                {
                    string userId = _accessor.HttpContext.Session.GetString("id");
                    await _questionService.TrueAnswer(model._id, userId);
                    return RedirectToAction("GetQuestion", "Question", new { model.level, @questionid = "" });
                }
            }
            return RedirectToAction("GetQuestion", "Question", new { model.level, @questionid = model._id });
        }
    }
}
