using Fahrenheit.Resource.Models.Base;
using Fahrenheit.Resource.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrenheit.Resource
{
    public interface IRepository
    {
        Task<User> GetUser(string name);

        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Gun>> GetGuns();
        Task<IEnumerable<Сharacter>> GetCharacters();
        Task<IEnumerable<Сharacter>> GetCharactersWithGuns();
        Task<IEnumerable<UserGun>> GetUserGuns(User user);
        Task<IEnumerable<UserCharacter>> GetUserCharacters(User user);
    }
}
