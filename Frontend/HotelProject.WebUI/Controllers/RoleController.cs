using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values =_roleManager.Roles.ToList();
            return View(values);
        }

        public IActionResult AddRole()
        {
            
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> AddRole(AddRoleViewModel model)
        {
            AppRole appRole = new AppRole()
            {
                Name=model.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
            if(result.Succeeded) {
                return RedirectToAction("Index","Role");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Inbdex", "Role");
        }

        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel model = new UpdateRoleViewModel()
            {
                RoleID = value.Id,
                RoleName=value.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleID);

            value.Name = model.RoleName;
            var result = await _roleManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }
            return View();
        }
    }
}
