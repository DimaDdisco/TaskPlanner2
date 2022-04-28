using System.ComponentModel.DataAnnotations;

using TaskPlanner2.Models.DataBase;

namespace TaskPlanner2.Models.ViewModel
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "Enter your email address")]
        [EmailAddress (ErrorMessage = "Invalid address")]
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

    public static class SignUpViewModelMapping
    {
        public static User ToUser(this SignupViewModel viewModel)
        {
            return new User
            {
                Mail = viewModel.Email,
                Login = viewModel.Login,
                Password = viewModel.Password
            };
        }
    }
}
