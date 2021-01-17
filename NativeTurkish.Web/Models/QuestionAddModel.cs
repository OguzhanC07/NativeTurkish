using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.Models
{
    public class QuestionAddModel
    {
        [Required(ErrorMessage = "Lütfen Seviyeyi seçiniz")]
        public string level { get; set; }
        [Required(ErrorMessage = "Lütfen Açıklamayı boş bırakmayın")]
        public string description { get; set; }
        public List<Alternative> alternatives { get; set; }
    }
}
