using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Port.Models;
using Port.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Port.Controllers
{
    public class AllProfilesController : Controller
    {
        private readonly ApplicationDbContext _coontext;

        public AllProfilesController(ApplicationDbContext context)
        {
            _coontext = context;
        }

        // Action to display all profiles
        // Assuming RegisterUserViewModel inherits from User and has additional properties
        public async Task<IActionResult> AllProfiles()
        {
            var users = await _coontext.Users.ToListAsync();

            // Map User entities to RegisterUserViewModel
            var userViewModels = users.Select(user => new RegisterUserViewModel
            {
                // Map properties here
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                // ... other properties
            }).ToList();

            return View("AllProfiles", userViewModels);
        }
    }
}
