using System;
using System.Collections.Generic;
using System.Text;

namespace NativeTurkish.Entities.Concrete
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }

        public List<QuestionChoices> QuestionChoices { get; set; }
        public List<UserQuestionAnswer> UserQuestionAnswers { get; set; }

    }
}
