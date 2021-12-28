using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Identity
{
    public class RegistrationViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password, ErrorMessage = "Passwords are not equal")]
        public string PasswordConfirm { get; set; }
    }
}