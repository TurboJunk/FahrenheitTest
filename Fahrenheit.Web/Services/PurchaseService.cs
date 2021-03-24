using Fahrenheit.Resource;
using Fahrenheit.Resource.Models.Base;
using Fahrenheit.Resource.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fahrenheit.Web.Services
{
    public class PurchaseService
    {
        private readonly DataContext db;

        public PurchaseService(DataContext db)
        {
            this.db = db;
        }

        public async Task<UserGun> BuyGunAsync(User User, Gun Gun)
        {
            User.Gold -= Gun.Cost;
            var userGun = new UserGun() { Owner = User, BaseGun = Gun };
            User.UserGuns.Add(userGun);
            await db.SaveChangesAsync();
            return userGun;
        }

        public async Task<UserCharacter> BuyCharacterAsync(User User, Сharacter Character)
        {
            User.Gold -= Character.Cost;
            var userCharacter = new UserCharacter() { Owner = User, BaseСharacter = Character };
            User.UserCharacters.Add(userCharacter);
            await db.SaveChangesAsync();
            return userCharacter;
        }
    }
}
