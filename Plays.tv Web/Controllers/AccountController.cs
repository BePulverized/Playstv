using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Plays.tv.Database;
using Plays.tv_App;
using Plays.tv_App.Controllers;

namespace Plays.tv_Web.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepo accountRepo = new AccountRepo(new AccountSQLiteContext());

        public ActionResult Login()
        {
            return View();
        }
        // POST: Account
        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            if (ModelState.IsValid)
            {

                    User user = (User)accountRepo.Login(name, password);
                    Session["LoggedAccountID"] = user.ID.ToString();
                    Session["LoggedAccountname"] = user.Name;
                    return RedirectToAction("Index", "Home");
                
            }

            return View();
        }

        public ActionResult LogOUt()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string name, string email, string password, string nickname)
        {
            if (ModelState.IsValid)
            {
                if (accountRepo.CreateUser(name, email, password, nickname))
                {

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }
        
    }
}