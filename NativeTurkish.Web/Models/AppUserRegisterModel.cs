using System.ComponentModel.DataAnnotations;

namespace NativeTurkish.Web.Models
{
    public class AppUserRegisterModel
    {
        [Required(ErrorMessage ="Ýsim alaný boþ geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage ="E-mail alaný boþ geçilemez"), EmailAddress(ErrorMessage ="Lütfen email adresini doðru girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Þifre alaný boþ geçilemez")]
        [StringLength(18, ErrorMessage = "Þifre maksimum {1}, minimum  {2} karakter uzunluðunda olmalýdýr.", MinimumLength = 3)]
        public string Password { get; set; }
    }
}