using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace etracker_api.Models
{
    public class Login
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password {get; set;}
    }
}
