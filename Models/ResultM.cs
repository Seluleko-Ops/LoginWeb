using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTechWeb.Models
{
    public class ResultM
    {
        public bool IsSuccessful { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }


    }
}
