using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrenheit.Resource.Models.User
{
    [Owned]
    public class LevelSystem
    {
        public int Value { get; set; }
        public int Experience { get; set; }
        public static int[] NextLvlExp { get; }
        static LevelSystem()
        {
            NextLvlExp = new int[] { 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 0};
        }

    }
}
