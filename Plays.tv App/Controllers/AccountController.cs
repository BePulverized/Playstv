using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Plays.tv_App.Database;

namespace Plays.tv_App.Controllers
{
    public class AccountController
    {
        // Deze klasse connect de forms met de database. Eventuele correcties na of voor database worden hier ook gedaan.
        private IAccountContext context;
        public static Account LoggedUser { get; set; }
        public AccountController(IAccountContext context)
        {
            this.context = context;
        }
        
        public Account Login(string username, string pw)
        {
            LoggedUser = context.Login(username, pw);
            return LoggedUser;

        }

        public List<Account> GetAll()
        {
            return context.GetAll();
        }

        public bool CreateUser(string name, string email, string password, string nickname)
        {
            return context.CreateUser(new User(0, name, email, password, nickname, "test.png"));
        }

        public string GetLatestNotification()
        {
            return context.GetLatestNotification(LoggedUser.ID);
        }
    }
}
