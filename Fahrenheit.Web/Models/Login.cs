﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fahrenheit.Web.Models
{
    public class Login
    {
        [Required]
        public string Name { get; set; }
    }
}
