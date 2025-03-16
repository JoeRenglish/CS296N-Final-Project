using CS296N_Final_Project.Data;
using CS296N_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CS296N_Final_Project.Controllers;

public class CharacterController : Controller
{ 
    ICharacterRepository repo;
    UserManager<AppUser> userManager;

    public CharacterController(ICharacterRepository r, UserManager<AppUser> u)
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
        return View(characters);
    }


    [Authorize]
    public IActionResult Character()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(Character model)
    {
        if (userManager != null)
        {
            model.AppUser = await userManager.GetUserAsync(User);
        }

        if (await repo.AddOrUpdateCharacterAsync(model) > 0)
        {
            return RedirectToAction("Index", new { characterId = model.CharacterId });
        }
        else
        {
            return View();
        }
    }

}