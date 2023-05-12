using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTechLogin.Entities
{
    public class User : EntityBase<int>
    {
        public string IdNumber { get; set; }
        public string Password { get; set; }

    }
}
