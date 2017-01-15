using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plays.tv_App.Controllers;
using Plays.tv_App.Database;

namespace Plays.tv_test
{
    [TestClass]
    public class GameRepositoryTest
    {
        private GameController gamerepo = new GameController(new GameMemoryContext());
        [TestMethod]
        public void GetAllGames()
        {
            // This list should be 3, they get initialized in the gamememorycontext 
            Assert.AreEqual(3, gamerepo.GetAll().Count);
        }
        [TestMethod]
        public void GetAllCats()
        {
            // This list should be 3, they get initialized in the gamememorycontext 
            Assert.AreEqual(3, gamerepo.GetAllCats().Count);
        }
    }
}
