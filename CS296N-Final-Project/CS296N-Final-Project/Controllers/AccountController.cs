using CS296N_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace CS296N_Final_Project.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<AppUser> signInManager;
    private readonly UserManager<AppUser> userManager;
    
    public AccountController(UserManager<AppUser> userM, SignInManager<AppUser> signInM)
    {
        userManager = userM;
        signInManager = signInM;
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser { UserName = model.Username };
            user.Name = user.UserName;
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult LogIn(string returnUrl = "")
    {
        var model = new LoginVM { ReturnUrl = returnUrl };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(LoginVM model)
    {
        if (ModelState.IsValid)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, 
                model.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
        }
        
        ModelState.AddModelError(string.Empty, "Invalid username or password.");
        return View(model);
    }

}