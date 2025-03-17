using CS296N_Final_Project.Data;
using CS296N_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS296N_Final_Project.Controllers;

public class GameController : Controller
{
    ICharacterRepository repo;
    UserManager<AppUser> userManager;
    
    public GameController(ICharacterRepository r, UserManager<AppUser> u)
    {
        repo = r;
        userManager = u;
    }

    [Authorize]
    public async Task<IActionResult> Index(Character model)
    {
        if (userManager != null)
        {
            model.AppUser = await userManager.GetUserAsync(User);
        }

        List<Character> characters;
        characters = await (from r in repo.Characters
            where r.AppUser == model.AppUser
            select r).ToListAsync<Character>();
        var character = characters.FirstOrDefault();
        if (character == null)
        {
            return RedirectToAction("Index", "Character");
        }
        else
        {
            return View(character);
        }
    }
}