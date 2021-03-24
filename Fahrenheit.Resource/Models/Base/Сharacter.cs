using Fahrenheit.Resource.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrenheit.Resource.Models.Base
{
    public class Сharacter
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public virtual IList<Gun> AviableGuns { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserCharacter> UserCharacters { get; set; }
        public Сharacter(string Name, int Cost)
        {
            AviableGuns = new List<Gun>();
            UserCharacters = new List<UserCharacter>();
            this.Name = Name;
            this.Cost = Cost;
        }
    }
}
