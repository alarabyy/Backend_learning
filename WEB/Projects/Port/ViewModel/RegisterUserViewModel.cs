using System.ComponentModel.DataAnnotations;

namespace Port.ViewModel
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }



    }
}
