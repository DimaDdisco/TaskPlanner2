using System.ComponentModel.DataAnnotations;

namespace TaskPlanner2.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password adress")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
