using BookingHotelRooms.Models;
using BookingHotelRooms.Models.Administration;
using BookingHotelRooms.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = model.RoleName };
                var result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Roles", "Administration");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Roles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> UsersInRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            var model = new UsersInRoleViewModel { Id = role.Id, Role = role.Name };


            foreach (var user in userManager.Users.ToList())
            {
                if (await userManager.IsInRoleAsync(user, model.Role))
                {
                    model.Users.Add(user);
                }
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            var model = new EditRoleViewModel { RoleName = role.Name };

            return View(model);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.Id);

                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Roles", "administration");
                }
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditUserRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var model = new EditUserViewModel { UserName = user.UserName , Roles= GetRolesAsSelectedList() };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditUserRole(EditUserViewModel model)
        {
                var newRole = HttpContext.Request.Form["SelectedUserRoleId"].ToString();
                var user = await userManager.FindByNameAsync(model.UserName);
                var roleList = await userManager.GetRolesAsync(user);
                var role = await roleManager.FindByNameAsync(roleList[0]);
                var resultRemove = await userManager.RemoveFromRoleAsync(user, role.Name);

                if (resultRemove.Succeeded)
                {
                    if((await userManager.AddToRoleAsync(user, newRole)).Succeeded)
                    {
                        return RedirectToAction("Roles", "Administration");
                    }
                    else
                    {
                        ModelState.AddModelError("", "You must choose a valid role! ");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "You must choose a valid role! ");
                }

            return View(model);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Roles", "administration");
            }

            return View();
        }

        private IEnumerable<SelectListItem> GetRolesAsSelectedList()
        {
            var roles = roleManager.Roles
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value=x.Name,
                                    Text=x.Name
                                }).ToList();

            return new SelectList(roles, "Value", "Text");
        }
    }
}
