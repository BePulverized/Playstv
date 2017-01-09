using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plays.tv.Database;
using Plays.tv_App;
using Plays.tv_App.Controllers;

namespace Plays.tv_Web.Controllers
{
    public class HomeController : Controller
    {
        private VideoRepo video = new VideoRepo(new VideoSQLiteContext());
        private ReactionRepo reaction = new ReactionRepo(new ReactionSQLContext());
        // GET: Home
        public ActionResult Index()
        {
            TempData["visited"] = 0;
            try
            {
                List<Video> recentVideos = video.GetRecentVideos();
                return View(recentVideos);
            }
            catch(Exception ex)
            {
                return new EmptyResult();
            }
        }

        public ActionResult Filter(int id)
        {
            List<Video> videos = null;
            switch (id)
            {
                case 1:
                {
                    videos = video.GetRecentVideos();
                }
                    break;
                case 2:
                {
                    videos = video.GetRecentVideos().OrderBy(o => o.Title).ToList();
                }
                    break;
                case 3:
                    {
                        videos = video.GetRecentVideos().OrderBy(o => o.Author.Name).ToList();
                    }
                    break;
            }
            
            return View(videos);
        }

        public ActionResult Search(string search)
        {
            try
            {
                List<Video> searchedVideos = video.SearchVideos(search);
                return View(searchedVideos);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }

        public ActionResult RenderImage(int id)
        {
            Byte[] thumbnail = this.video.GetVideo(id).Thumbnail;
            return File(thumbnail, "image/jpg");
        }


    }
}