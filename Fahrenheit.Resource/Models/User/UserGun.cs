using Fahrenheit.Resource.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrenheit.Resource.Models.User
{
    public class UserGun
    {
        public int Id { get; set; }
        [JsonIgnore]
        public virtual User Owner { get; set; }
        [JsonIgnore]
        public virtual Gun BaseGun { get; set; }
        public LevelSystem Level { get; set; }
        public UserGun()
        {
            Level = new LevelSystem();
        }
        public double Damage
        {
            get { return Math.Pow(1.1, Level.Value) * BaseGun.Damage; }
        }
        public double FireRate
        {
            get { return Math.Pow(1.1, Level.Value) * BaseGun.FireRate; }
        }
        public double ReloadSpeed
        {
            get { return Math.Pow(1.1, Level.Value) * BaseGun.ReloadSpeed; }
        }
        public double MagazineSize
        {
            get { return Math.Pow(1.1, Level.Value) * BaseGun.MagazineSize; }
        }
    }
}
