using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plays.tv.Database;
using Plays.tv_App;
using Plays.tv_App.Controllers;
using Plays.tv_App.Database;

namespace WebApplication1.Controllers
{
    public class VideoController : Controller
    {
        private VideoRepo video = new VideoRepo(new VideoSQLiteContext());
        // GET: Video\VideoList
        public ActionResult VideoList()
        {
            
            List<Video> videos = video.GetRecentVideos();
            return View(videos);
        }

        public ActionResult Watch(int id)
        {
            Video video = this.video.GetVideo(id);
            return View(video);
        }
    }
}