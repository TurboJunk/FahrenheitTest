using Fahrenheit.Resource.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrenheit.Resource.Models.Base
{
    public class Gun
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int Damage { get; set; }
        public int FireRate { get; set; }
        public int ReloadSpeed { get; set; }
        public int MagazineSize { get; set; }
        [JsonIgnore]
        public virtual ICollection<Сharacter> Сharacters { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserGun> UserGuns { get; set; }
        public Gun(string Name, int Cost)
        {
            Сharacters = new List<Сharacter>();
            UserGuns = new List<UserGun>();
            this.Name = Name;
            this.Cost = Cost;
        }
    }
}
