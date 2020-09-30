using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Model
{
    public class UserModel
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
