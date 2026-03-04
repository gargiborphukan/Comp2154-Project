

using System.ComponentModel.DataAnnotations;

namespace Comp2154_System_Development_Project.Models
{
//2ND PART
    public class RegisterViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; } //students email

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } //paswword

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } //confirm password
    }
}