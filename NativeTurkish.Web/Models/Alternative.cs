using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NativeTurkish.Web.Models
{
    public class Alternative
    {
        public bool isCorrect { get; set; }
        [Required(ErrorMessage ="Cevap alanı boş geçilemez")]
        public string answer { get; set; }
    }
}
