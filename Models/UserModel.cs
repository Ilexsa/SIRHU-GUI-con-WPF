using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string nickname { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
    }
}
