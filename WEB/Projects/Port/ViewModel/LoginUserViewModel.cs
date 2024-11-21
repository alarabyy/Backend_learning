using System.ComponentModel.DataAnnotations;

namespace Port.ViewModel
{
    public class LoginUserViewModel
    {
        [EmailAddress]
        [Required]
        [DataType(DataType.Password)]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="remmber me!!")]
        public bool RememberMe { get; set; }
    }
}
