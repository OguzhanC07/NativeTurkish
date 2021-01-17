using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.Models
{
    public class RegisterLoginModel
    {
        public AppUserRegisterModel AppUserRegisterModel { get; set; }
        public AppUserLoginModel AppUserLoginModel { get; set; }
    }
}
