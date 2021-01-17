using System.ComponentModel.DataAnnotations;

namespace NativeTurkish.Web.Models
{
    public class AppUserLoginModel
    {
        [Required(ErrorMessage = "E-mail alanı boş geçilemez"), EmailAddress(ErrorMessage = "Lütfen email adresini doğru girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        [StringLength(18, ErrorMessage = "Şifre maksimum {1}, minimum  {2} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
        public string Password { get; set; }
    }
}