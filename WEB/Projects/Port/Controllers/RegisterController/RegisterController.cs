using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Port.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Port.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public RegisterController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userViewModel.UserName,
                    Email = userViewModel.Email,
                    PhoneNumber = userViewModel.Phone
                };

                var result = await userManager.CreateAsync(user, userViewModel.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(userViewModel);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> SaveLogin(LoginUserViewModel loginUserView)
        {
            
                if (ModelState.IsValid)
                {
                    var usersWithEmail = userManager.Users.Where(u => u.Email == loginUserView.Email).ToList();
                    var appUser = usersWithEmail.FirstOrDefault();

                    if (appUser == null)
                    {
                        ModelState.AddModelError("", "No user found with this email.");
                    }
                    else if (usersWithEmail.Count > 1)
                    {
                        ModelState.AddModelError("", "There are multiple accounts with this email. Please contact support.");
                    }
                    else
                    {
                        bool found = await userManager.CheckPasswordAsync(appUser, loginUserView.Password);
                        if (found)
                        {
                            var claims = new List<Claim>
                        {
                            new Claim("PhoneNumber", appUser.PhoneNumber),
                            new Claim("Email", appUser.Email)
                        };
                            await signInManager.SignInWithClaimsAsync(appUser, loginUserView.RememberMe, claims);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email or password is incorrect.");
                        }
                    
                }
            }
            return View("Login", loginUserView);
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            TempData["Message"] = "SignOut sucsess";
            return RedirectToAction("Login");
        }
    }
}
