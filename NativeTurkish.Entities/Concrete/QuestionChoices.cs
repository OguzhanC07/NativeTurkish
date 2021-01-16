using System;
using System.Collections.Generic;
using System.Text;

namespace NativeTurkish.Entities.Concrete
{
    public class QuestionChoices
    {
        public int Id { get; set; }

        public string Choice { get; set; }
        public string IsRightChoice { get; set; }
        
        
        
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public List<UserQuestionAnswer> UserQuestionAnswers { get; set; }

    }
}
