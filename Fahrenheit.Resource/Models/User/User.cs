using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrenheit.Resource.Models.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public LevelSystem Level { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserGun> UserGuns { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserCharacter> UserCharacters { get; set; }
        public User(string Name)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            UserGuns = new List<UserGun>();
            UserCharacters = new List<UserCharacter>();
            Level = new LevelSystem();
        }
    }
}
