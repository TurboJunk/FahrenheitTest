using Fahrenheit.Resource;
using Fahrenheit.Resource.Models.Base;
using Fahrenheit.Resource.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fahrenheit.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly IRepository db;

        public HomeController(IRepository db)
        {
            this.db = db;
            //if (!db.GetUsers().Result.Any())
            //{
            //    Seeddb();
            //}
        }

        [HttpGet]
        public async Task<IActionResult> GetGuns()
        {
            return Ok(await db.GetGuns());
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            var characterList = await db.GetCharactersWithGuns();
            return Ok(characterList);
        }

        //private async Task Seeddb()
        //{
        //    var guns = new Gun[]
        //    {
        //            new Gun("Gun1", 10){ Damage = 10, FireRate = 2, ReloadSpeed = 10, MagazineSize = 3 },
        //            new Gun("Gun2", 15){ Damage = 5, FireRate = 5, ReloadSpeed = 7, MagazineSize = 10 },
        //            new Gun("Gun3", 20){ Damage = 15, FireRate = 1, ReloadSpeed = 20, MagazineSize = 1 }
        //    };

        //    var characters = new Сharacter[]
        //    {
        //            new Сharacter("Char1", 100 ),
        //            new Сharacter("Char2", 150 )
        //    };

        //    characters[0].AviableGuns.Add(guns[0]);
        //    characters[0].AviableGuns.Add(guns[2]);

        //    characters[1].AviableGuns.Add(guns[1]);
        //    characters[1].AviableGuns.Add(guns[2]);

        //    var users = new User[]
        //    {
        //            new User("admin"){ Gold = 10000 }
        //    };

        //    var usersGuns = new UserGun[]
        //    {
        //            new UserGun(){ Owner = users[0], BaseGun = guns[0] },
        //            new UserGun(){ Owner = users[0], BaseGun = guns[1] }
        //    };

        //    var usersCharacters = new UserCharacter[]
        //    {
        //            new UserCharacter(){ Owner = users[0], BaseСharacter = characters[0] }
        //    };

        //    db.Guns.AddRange(guns);
        //    db.Users.AddRange(users);
        //    db.Characters.AddRange(characters);
        //    db.UsersGuns.AddRange(usersGuns);
        //    db.UsersCharacters.AddRange(usersCharacters);
        //    await db.SaveChangesAsync();
        //}
    }
}
