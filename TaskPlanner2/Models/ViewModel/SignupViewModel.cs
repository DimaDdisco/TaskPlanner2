using System.ComponentModel.DataAnnotations;

namespace TaskPlanner2.Models.ViewModel
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "Enter your email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your user name")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat your password")]
        [Compare("Password", ErrorMessage = "Passwords are different")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
