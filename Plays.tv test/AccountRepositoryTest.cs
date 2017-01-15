using System;
using System.Collections.Generic;
using Plays.tv_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plays.tv_App.Controllers;
using Plays.tv_App.Database;

namespace Plays.tv_test
{
    [TestClass]
    public class AccountRepositoryTest
    {
        AccountRepository accountRepo = new AccountRepository(new AccountMemoryContext());
        [TestMethod]
        public void Login()
        {
            Account account = accountRepo.Login("Jeroen", "hoi123");
            Account expectedAccount = new User(2, "Jeroen", "jeroen@gmail.com", "hoi123", "Bossintraining", string.Empty);
            Assert.AreEqual(expectedAccount.ID, account.ID);
            Assert.AreEqual(expectedAccount.Email, account.Email);
            Assert.AreEqual(expectedAccount.Name, account.Name);
        }
        [TestMethod]
        public void Delete()
        {
            List<Account> users = accountRepo.GetAll();
            bool succes = accountRepo.Delete(0);
            Assert.AreEqual(true, succes);
            // Users started with 4, should be 3 now
            Assert.AreEqual(3, users.Count);
            bool error = accountRepo.Delete(10);
            Assert.AreEqual(false, error);
        }
        [TestMethod]
        public void CreateUsers()
        {
            bool succes = accountRepo.CreateUser("Jordy", "jordy150@gmail.com", "ho1i23", "BePulverized");
            Assert.AreEqual(true, succes);
            
            // Users started with 4, should be 5 now
            Assert.AreEqual(5, accountRepo.GetAll().Count);
            bool adminsucces = accountRepo.CreateAdmin("Jordy", "jordy150@gmail.com", "hoi123", Permissions.FULLCONTROL);
            Assert.AreEqual(true, adminsucces);
            //Users should be 6 now after adding another admin
            Assert.AreEqual(6, accountRepo.GetAll().Count);
        }
    }
}
