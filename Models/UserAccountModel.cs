using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public class UserAccountModel
    {
        public string Nickname { get; set; }
        public string DisplayName { get; set; }
        public byte [] ProfilePicture { get; set; }
    }
}
