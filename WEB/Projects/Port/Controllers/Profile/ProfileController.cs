using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using Port.ViewModel;
using System.Security.Claims;

public class ProfileController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfileController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound(); // Handle user not found scenario
        }

        var model = new RegisterUserViewModel // Assuming you're using ProfileViewModel in the view
        {
            UserName = user.UserName,
            Email = user.Email,
            Phone = user.PhoneNumber // Consider masking or allowing editing if needed
        };

        return View(model);
    }
}