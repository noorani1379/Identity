using System.ComponentModel.DataAnnotations;

namespace Identity.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MaxLength(200)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]

        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(otherProperty: nameof(Password))]

        public string RePassword { get; set; }
    }
}
