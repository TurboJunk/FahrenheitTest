using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrenheit.Resource.Models.Base;
using Newtonsoft.Json;

namespace Fahrenheit.Resource.Models.User
{
    public class UserCharacter
    {
        public int Id { get; set; }
        [JsonIgnore]
        public virtual User Owner { get; set; }
        [JsonIgnore]
        public virtual Сharacter BaseСharacter { get; set; }
        public UserCharacter()
        {
        }
    }
}
