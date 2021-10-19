using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLogin.Model
{
    public class Login
    {
        [Required]
        public String email {get;set;}
        [Required]
        public String senha { get; set; }
    }
}
