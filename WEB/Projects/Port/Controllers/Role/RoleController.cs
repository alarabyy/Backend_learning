using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using Port.ViewModel;

namespace Port.Controllers.Role
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole>  roleManager;

        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            this.roleManager = _roleManager;
        }

        [HttpGet]
        public IActionResult Role()
        {
            return View("Role");
        }

        [HttpPost]
        public async Task< IActionResult > SaveRole(RoleViewModel roleView)
        {
            if (ModelState.IsValid == true)
            {
                //save db
                IdentityRole role = new IdentityRole();
                role.Name = roleView.RoleName;
                IdentityResult result =  await  roleManager.CreateAsync(role);
                if (result.Succeeded == true) 
                {
                    ViewBag.sucess = true;
                    return View("Role");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Role", roleView);

        }
    }
}
