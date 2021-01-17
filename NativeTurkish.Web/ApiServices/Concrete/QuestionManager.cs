using Microsoft.AspNetCore.Http;
using NativeTurkish.Web.ApiServices.Interfaces;
using NativeTurkish.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NativeTurkish.Web.ApiServices.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IHttpContextAccessor _accessor;
        HttpClient _httpClient;

        public QuestionManager(IHttpContextAccessor accessor, HttpClient httpClient)
        {
            _accessor = accessor;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:3000/api/v1/questions/");
        }


        public async Task<List<QuestionListModel>> GetAllQuestions()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            var responseMessage = await _httpClient.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<QuestionListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }


        public async Task<QuestionListModel> GetQuestionByIdAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            var responseMessage = await _httpClient.GetAsync($"{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<QuestionListModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task AddAsync(QuestionAddModel model)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            var json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync("", content);
        }

        public async Task UpdateAsync(QuestionListModel model)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            var json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PatchAsync($"{model._id}", content);
        }

        public async Task DeleteAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            var responseMessage = await _httpClient.DeleteAsync($"{id}");
        }


        public async Task<QuestionListModel> GetQuestionByLevel(string level)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));
            var userId = _accessor.HttpContext.Session.GetString("id");

            var responseMessage = await _httpClient.GetAsync($"quizQuestion?level={level}&userId={userId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<QuestionListModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }



        }
    }
}
