using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.Models
{
    public class QuestionListModel
    {
        public string _id { get; set; }
        public string level { get; set; }
        public string description { get; set; }
        public List<Alternative> alternatives { get; set; }
    }
}
