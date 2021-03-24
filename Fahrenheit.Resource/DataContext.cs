using Fahrenheit.Resource.Models.Base;
using Fahrenheit.Resource.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrenheit.Resource
{
    public class DataContext : DbContext, IRepository
    {
        public DbSet<Gun> Guns { get; set; }
        public DbSet<Сharacter> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGun> UsersGuns { get; set; }
        public DbSet<UserCharacter> UsersCharacters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserGun>().OwnsOne(g => g.Level);
            builder.Entity<User>().OwnsOne(g => g.Level);
        }

        public async Task<IEnumerable<Gun>> GetGuns()
        {
            return await Guns.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Сharacter>> GetCharacters()
        {
            return await Characters.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Сharacter>> GetCharactersWithGuns()
        {
            return await Characters.AsNoTracking().Include(b => b.AviableGuns).ToListAsync();
        }

        public async Task<User> GetUser(string name)
        {
            return await Users.SingleOrDefaultAsync(u => u.Name == name);
        }

        public async Task<IEnumerable<UserGun>> GetUserGuns(User user)
        {
            return await UsersGuns.Include(ug => ug.Owner).Include(ug => ug.BaseGun).Where(ug => ug.Owner == user).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<UserCharacter>> GetUserCharacters(User user)
        {
            return await UsersCharacters.Include(ug => ug.Owner).Where(ug => ug.Owner == user).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Users.AsNoTracking().ToListAsync();
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DataContext() : base()
        {

        }
    }
}
