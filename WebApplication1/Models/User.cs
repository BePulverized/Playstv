using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App
{
    public class User:Account
    {
        public string Nickname { get; set; }
        public string ProfilePic { get; set; }

        public User(int id, string name, string email, string password, string nickname, string profilePic) : base(id, name, email, password)
        {
            Nickname = nickname;
            ProfilePic = profilePic;
        }
    }
}
