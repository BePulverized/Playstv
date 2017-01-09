using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App
{
    public class Admin:Account
    {

        public Permissions Permission { get; set; }
        public Admin(int id, string name, string email, string password, Permissions permission) : base(id, name, email, password)
        {
            Permission = permission;
        }
    }
}
