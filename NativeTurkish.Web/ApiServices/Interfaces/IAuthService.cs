using System.Threading.Tasks;
using NativeTurkish.Web.Models;

namespace NativeTurkish.Web.ApiServices.Interfaces
{
    public interface IAuthService
    {
        Task<string> SignIn(AppUserLoginModel loginModel);
        Task<string> SignUp(AppUserRegisterModel registerModel);
    }
}