using Microsoft.AspNetCore.Http;
using NativeTurkish.Web.ApiServices.Interfaces;
using NativeTurkish.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NativeTurkish.Web.ApiServices.Concrete
{
    public class UserManager : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public UserManager(HttpClient httpClient, IHttpContextAccessor accessor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:3000/api/v1/users/");
            _accessor = accessor;
        }
        public async Task<List<UserListModel>> GetAllUsersAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));
            var responseMessage = await _httpClient.GetAsync("");

            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<UserListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteUserAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessor.HttpContext.Session.GetString("token"));

            var responseMessage = await _httpClient.DeleteAsync($"{id}");
        }

    }
}
