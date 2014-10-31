using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class RegisterViewModel : ObjectLibrary.ApplicationUser
    {
        [Required]
        [Display(Name = @"E-Mail")]
        public new string Email { get; set; }

        [Required]
        [Display(Name = @"First Name")]
        public new string FirstName { get; set; }

        [Required]
        [Display(Name = @"Last Name")]
        public new string LastName { get; set; }

        [Display(Name = @"Phone Number")]
        public new string PhoneNumber { get; set; }


        [Required]
        [Display(Name = @"Address")]
        public new string Address { get; set; }
        [Required]
        [Display(Name = @"City")]
        public new string City { get; set; }
        [Required]
        [Display(Name = @"State")]
        public new string State { get; set; }
        [Required]
        [Display(Name = @"Zip")]
        public new string Zip { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = @"The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = @"Password")]
        public new string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = @"Confirm password")]
        [Compare("Password", ErrorMessage = @"The password and confirmation password do not match.")]
        public new string ConfirmPassword { get; set; }
    }
}