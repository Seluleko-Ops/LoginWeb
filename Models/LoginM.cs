using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASTechWeb.Models
{
    public class LoginM
    {
        [Required]
        [Display(Name ="ID/Passport")]
        public string IdNumber { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string Password { get; set; }

    }
}
