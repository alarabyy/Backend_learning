using System.ComponentModel.DataAnnotations;

namespace Port.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
