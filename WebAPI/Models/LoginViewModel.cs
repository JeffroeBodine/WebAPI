using System.ComponentModel.DataAnnotations;
using ObjectLibrary;

namespace WebAPI.Models
{
    public class LoginViewModel : ApplicationUser
    {
        [Required]
        [Display(Name = @"E-Mail")]
        public new string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Password")]
        public new string Password { get; set; }

        [Display(Name = @"Remember me?")]
        public bool RememberMe { get; set; }
    }
}