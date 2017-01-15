using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App.Database
{
    public interface IAccountContext
    {
        //Accountcontext Interface
        Account Login(string username, string pw);
        List<Account> GetAll();
        bool Delete(int id);
        bool CreateUser(User user);
        bool CreateAdmin(Admin admin);

       
    }
}
