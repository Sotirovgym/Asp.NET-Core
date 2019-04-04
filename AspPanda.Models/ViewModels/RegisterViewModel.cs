namespace AspPanda.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(2, ErrorMessage = "Username cannot be less than 2 symbols")]
        [MaxLength(50, ErrorMessage = "Username cannot be longer than 50 symbols")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(20, ErrorMessage = "Password cannot be longer than 20 symbols")]
        [MinLength(6, ErrorMessage = "Password cannot be less than 6 symbols")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Confirm password should me same as password.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-z A-Z]+@[a-z A-Z]+\.[a-z A-Z]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
    }
}
