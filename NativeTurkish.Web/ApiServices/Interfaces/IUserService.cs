using NativeTurkish.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.ApiServices.Interfaces
{
    public interface IUserService
    {
        Task<List<UserListModel>> GetAllUsersAsync();
    }
}
