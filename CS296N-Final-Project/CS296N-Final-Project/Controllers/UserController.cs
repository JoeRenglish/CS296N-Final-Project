using CS296N_Final_Project.Data;
using CS296N_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS296N_Final_Project.Controllers;

public class UserController : Controller
{
    ICharacterRepository _repo;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public UserController(UserManager<AppUser> userM, RoleManager<IdentityRole> roleM, ICharacterRepository r)
    {
        _userManager = userM;
        _roleManager = roleM;
        _repo = r;
    }

    public async Task<IActionResult> Index()
    {
        var users = new List<AppUser>();
        users = await _userManager.Users.ToListAsync();
        foreach (var user in users) user.RoleNames = await _userManager.GetRolesAsync(user);
        var model = new UserVM
        {
            Users = users,
            Roles = _roleManager.Roles
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            var characters = _repo.Characters.ToList();
            foreach (Character c in characters)
            {
                if (c.AppUser == user)
                {
                    _repo.DeleteCharacter(c.CharacterId);
                }
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errorMessage = "";
                foreach (var error in result.Errors)
                {
                    errorMessage = error.Description + " | ";
                }
                TempData["message"] = errorMessage;
            }
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddToAdmin(string id)
    {
        var adminRole = await _roleManager.FindByNameAsync("Admin");
        if (adminRole == null)
        {
            TempData["message"] = "Admin role doesn't exist! " + "Click 'Create Admin Role' button to create new admin role.";
        }
        else
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, adminRole.Name);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromAdmin(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        await _userManager.RemoveFromRoleAsync(user, "Admin");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteRole(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        await _roleManager.DeleteAsync(role);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdminRole()
    {
        await _roleManager.CreateAsync(new IdentityRole("Admin"));
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(RegisterVM model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser { UserName = model.Username };
            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (result.Succeeded) return RedirectToAction("Index");
            
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
        }
        
        return View(model);
    }




}