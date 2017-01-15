using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App.Database
{
    public class AccountMemoryContext:IAccountContext
    {
        public List<Account> Users { get; private set; }
        public List<Notification> Notifications { get; private set; }
        public Account Login(string username, string pw)
        {
            Account returnaccount = null;
            foreach (Account account in Users)
            {
                if (account.Name == username && account.Password == pw)
                {
                    returnaccount = account;
                }
            }
            return returnaccount;
        }

        public List<Account> GetAll()
        {
            Users = new List<Account>();
            Users.Add(new Admin(0, "Jordy", "jordy150@gmail.com", "hoi123", Permissions.FULLCONTROL));
            Users.Add(new Admin(1, "Jan", "roelofsen@gmail.com", "jan123", Permissions.FULLCONTROL));
            Users.Add(new User(2, "Jeroen", "jeroen@gmail.com", "hoi123", "Bossintraining", string.Empty));
            Users.Add(new User(2, "Laurent", "saltyscrub@gmail.com", "hoi123", "TheSaltyScrub", string.Empty));


            return Users;


        }

        public bool Delete(int id)
        {
            foreach (Account account in Users)
            {
                if (account.ID == id)
                {
                    Users.Remove(account);
                    return true;
                }
            }
            return false;
        }

        public bool CreateUser(User user)
        {
            Users.Add(user);
            return true;
        }

        public bool CreateAdmin(Admin admin)
        {
            Users.Add(admin);
            return true;
        }

        
    }
}
