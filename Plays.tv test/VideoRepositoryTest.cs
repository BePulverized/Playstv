using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plays.tv_App;
using Plays.tv_App.Controllers;
using Plays.tv_App.Database;

namespace Plays.tv_test
{
    [TestClass]
    public class VideoRepositoryTest
    {
        private VideoController videorepo = new VideoController(new VideoMemoryContext());
        [TestMethod]
        public void GetVideoByUser()
        {
            // There are 2 video's initialized for this user in the memorycontext
            Assert.AreEqual(2, videorepo.GetVideosByUser(new User(0, "Jordy", "jordy150@gmail.com", "hoi123", "BePulverized", "")).Count);
        }
        [TestMethod]
        public void Insert()
        {
            Assert.AreEqual(true,
                videorepo.Insert(new Video(0, new User(0, "Jordy", "jordy150@gmail.com", "hoi123", "BePUvlerized", ""),
                    0, "test", new Category("MOBA", 0), new Feedback(0, 0), new Game(0, "League of legends"))));
        }
    }
}
