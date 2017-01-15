using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plays.tv_App;
using Plays.tv_App.Controllers;
using Plays.tv_Web.Database.Memory;

namespace Plays.tv_Web_Test
{
    [TestClass]
    public class VideoRepositoryTest
    {
        private VideoRepo videorepo = new VideoRepo(new VideoMemoryContext());
        [TestMethod]
        public void Insert()
        {
            Assert.AreEqual(true,
                videorepo.Insert(new Video(0, new User(0, "Jordy", "jordy150@gmail.com", "hoi123", "BePUvlerized", ""),
                    0, "test", new Category("MOBA", 0), new Feedback(0, 0), new Game(0, "League of legends"))));

        }
        [TestMethod]
        public void GetVideoByUser()
        {
            // Should be 2 since there are 2 videos in the memorycontext with id 0
            Assert.AreEqual(2, videorepo.GetVideosByUser(new User(0, "jordy", "jord150@gmail.com", "hoi123", "bepuvlerized", "")).Count);
        }
        [TestMethod]
        public void GetRecentVideos()
        {
            // This method returns the last video in the list the id should be the same
            Assert.AreEqual(videorepo.GetallVideos()[videorepo.GetallVideos().Count - 1].ID, videorepo.GetRecentVideos()[0].ID);
        }

        [TestMethod]
        public void GetVideo()
        {
            // Id's should be the same since it looks up the video based on id
            Assert.AreEqual(0, videorepo.GetVideo(0).ID);
        }

        [TestMethod]
        public void SearchVideos()
        {
            // There are 4 videos in the memorycontext with the title testvideo
            Assert.AreEqual(4, videorepo.SearchVideos("testvideo").Count);
        }
        [TestMethod]
        public void InsertFeedback()
        {
            // Should be true if insert went like it should
            Assert.AreEqual(true, videorepo.InsertFeedback(new Feedback(0, 0, 0, 0)));
            // This should be 1 higher then it was, which was 4 in the memorycontext
            Assert.AreEqual(5, videorepo.GetFeedback().Count);
        }
        [TestMethod]
        public void View()
        {
            //Cannot really be tested since it is a stored procedure in the database
            Assert.AreEqual(true, videorepo.View(0));
        }
    }
}
