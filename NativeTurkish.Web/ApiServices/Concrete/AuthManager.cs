using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NativeTurkish.Web.ApiServices.Interfaces;
using NativeTurkish.Web.Models;
using Newtonsoft.Json;

namespace NativeTurkish.Web.ApiServices.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public AuthManager(HttpClient httpClient, IHttpContextAccessor accessor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("http://localhost:3000/api/v1/users/");
            _accessor = accessor;
        }


        public async Task<string> SignIn(AppUserLoginModel loginModel)
        {
            var json = JsonConvert.SerializeObject(loginModel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync("login", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var tokenAndRole = JsonConvert.DeserializeObject<LoginCredentials>(await responseMessage.Content.ReadAsStringAsync());
                _accessor.HttpContext.Session.SetString("token", tokenAndRole.Token);
                _accessor.HttpContext.Session.SetString("id", tokenAndRole.Id);
                _accessor.HttpContext.Session.SetString("name", tokenAndRole.Name);
                _accessor.HttpContext.Session.SetString("role", tokenAndRole.Role);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAndRole.Token);

                return "";
            }
            else
            {
                return "Kullanıcı adı veya şifre yanlış";
            }

        }

        public async Task<string> SignUp(AppUserRegisterModel registerModel)
        {
            var json = JsonConvert.SerializeObject(registerModel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync("signup", content);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return "Sistemde bu e-postayı kullanan birisi var. Lütfen başka e-posta deneyiniz.";
            }
            else
            {
                return "";
            }
        }
    }
}