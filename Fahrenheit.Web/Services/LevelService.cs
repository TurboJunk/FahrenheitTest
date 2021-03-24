using Fahrenheit.Resource;
using Fahrenheit.Resource.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fahrenheit.Web.Services
{
    public class LevelService
    {
        private readonly DataContext db;

        public LevelService(DataContext db)
        {
            this.db = db;
        }

        public async Task AddExperience(LevelSystem level, int amount)
        {
            level.Experience += amount;
            while (level.Experience >= LevelSystem.NextLvlExp[level.Value])
            {
                level.Value++;
                level.Experience -= LevelSystem.NextLvlExp[level.Value];
            }
            await db.SaveChangesAsync();
        }
    }
}
