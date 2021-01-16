using System;
using System.Collections.Generic;
using System.Text;

namespace NativeTurkish.Entities.Concrete
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
        public List<UserQuestionAnswer> UserQuestionAnswers { get; set; }
    }
}
