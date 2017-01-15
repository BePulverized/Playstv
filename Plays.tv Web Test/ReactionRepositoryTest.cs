using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plays.tv_App.Controllers;
using Plays.tv_Web.Database.Memory;

namespace Plays.tv_Web_Test
{
    [TestClass]
    public class ReactionRepositoryTest
    {
        private ReactionRepo reactionrepo = new ReactionRepo(new ReactionMemoryContext());
        [TestMethod]
        public void GetReactionsForVideo()
        {
            // There are 3 videos with id 0 initialized in the memorycontext so this method should return 3 reaction objects
            Assert.AreEqual(3, reactionrepo.GetReactionsForVideo(0).Count);
        }
        [TestMethod]
        public void Insert()
        {
            Assert.AreEqual(true, reactionrepo.Insert("testreaction", 0, 0));
            // Check if it was added to the list, list should be 4 then because we added the reaction with video id 0
            Assert.AreEqual(4, reactionrepo.GetReactionsForVideo(0).Count);
        }

    }
}
