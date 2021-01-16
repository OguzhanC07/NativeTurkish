using System;
using System.Collections.Generic;
using System.Text;

namespace NativeTurkish.Entities.Concrete
{
    public class UserQuestionAnswer
    {
        public int Id { get; set; }
        public bool IsTrue { get; set; }
        public DateTime Answer_Time { get; set; }

        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int ChoiceId { get; set; }
        public QuestionChoices QuestionChoices { get; set; }
    }
}
