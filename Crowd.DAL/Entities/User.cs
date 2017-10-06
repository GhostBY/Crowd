using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowd.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
