using Fahrenheit.Resource;
using Fahrenheit.Resource.Models.Base;
using Fahrenheit.Resource.Models.User;
using Fahrenheit.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fahrenheit.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private Guid userId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private User currentUser => db.Users.Single(u => u.Id == userId);

        private readonly DataContext db;
        private readonly PurchaseService purchase;
        private readonly LevelService level;

        public UserController(DataContext db, PurchaseService purchase, LevelService level)
        {
            this.db = db;
            this.purchase = purchase;
            this.level = level;
        }

        [HttpGet]
        public async Task<IActionResult> GetGuns()
        {
            var gunsList = await db.Entry(currentUser).Collection(u => u.UserGuns).Query().Include(ug => ug.BaseGun).AsNoTracking().ToListAsync();
            return Ok(gunsList);
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            var charactersList = await db.Entry(currentUser).Collection(u => u.UserCharacters).Query().AsNoTracking().ToListAsync();
            return Ok(charactersList);
        }

        [HttpPost]
        public async Task<IActionResult> BuyGun(int id)
        {
            var gun = db.Guns.AsNoTracking().SingleOrDefault(g => g.Id == id);
            if (gun != null)
            {
                if (currentUser.Gold >= gun.Cost)
                {
                    var duplicate = db.Entry(currentUser).Collection(u => u.UserGuns).Query().Any(g => g.BaseGun == gun);
                    if (!duplicate)
                    {
                        var result = await purchase.BuyGunAsync(currentUser, gun);
                        return Ok(result);
                    }
                    return Content("gun already exists");
                }
                return Content("not enough gold");
            }
            return BadRequest(id);
        }

        [HttpPost]
        public async Task<IActionResult> BuyCharacter(int id)
        {
            var сharacter = db.Characters.AsNoTracking().SingleOrDefault(c => c.Id == id);
            if (сharacter != null)
            {
                if (currentUser.Gold >= сharacter.Cost)
                {
                    var duplicate = db.Entry(currentUser).Collection(u => u.UserCharacters).Query().Any(c => c.BaseСharacter == сharacter);
                    if (!duplicate)
                    {
                        var result = await purchase.BuyCharacterAsync(currentUser, сharacter);
                        return Ok(result);
                    }
                    return Content("character already exists");
                }
                return Content("not enough gold");
            }
            return BadRequest(id);
        }

        [HttpPut]
        public async Task<IActionResult> AddGunExp(int id, int amount)
        {
            var gunlevel = db.Entry(currentUser).Collection(u => u.UserGuns).Query().Single(ug => ug.Id == id).Level;
            await level.AddExperience(gunlevel, amount);
            return Ok(gunlevel);
        }

        [HttpPut]
        public async Task<IActionResult> AddUserExp(int amount)
        {
            await level.AddExperience(currentUser.Level, amount);
            return Ok(currentUser.Level);
        }
    }
}
