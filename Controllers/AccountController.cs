using BookingHotelRooms.Models;
using BookingHotelRooms.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
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
        public async Task<ActionResult> Register(RegisterUser user)
        {
            if (userManager.Users.FirstOrDefault(x => x.Email == user.Email) != null && userManager.Users.FirstOrDefault(x => x.UserName == user.Name) != null)
            {
                ModelState.AddModelError("Mail", "Email is already used!");
            }

            var appUser = new AppUser { UserName = user.Name, Email = user.Email };
            var result = await userManager.CreateAsync(appUser, user.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(appUser, "User");
                await signInManager.SignInAsync(appUser, false);

                return RedirectToAction("Index", "Rooms");

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }          
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Rooms");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Rooms");
        }
    }
}
