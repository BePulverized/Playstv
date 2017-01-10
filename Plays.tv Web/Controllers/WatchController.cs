using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights.Web;
using Plays.tv.Database;
using Plays.tv_App;
using Plays.tv_App.Controllers;

namespace Plays.tv_Web.Controllers
{
    public class WatchController : Controller
    {
        private VideoRepo video = new VideoRepo(new VideoSQLiteContext());
        private ReactionRepo reaction = new ReactionRepo(new ReactionSQLContext());
        

        // GET: Watch
        [HttpGet]
        public ActionResult Index(int id)
        {
            try
            {
                if (Convert.ToInt32(TempData["Visited"]) != 1)
                {
                    video.View(id);
                    TempData["visited"] = 1;
                }
                TempData["videoid"] = Convert.ToString(id);
                ViewModel model = new ViewModel();
                model.Video = video.GetVideo(id);
                model.Reactions = reaction.GetReactionsForVideo(id);


                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }

        

        public ActionResult GetVideo(int id)
        {
            Byte[] video = this.video.GetVideo(id).Data;
            string mimeType = "video/mp4";
            return File(video,mimeType);
        }

        public ActionResult RenderImage(int id)
        {
            Byte[] thumbnail = this.video.GetVideo(id).Thumbnail;
            return File(thumbnail, "image/jpg");
        }

        public class ViewModel
        {
            public Video Video { get; set; }
            public List<Reaction> Reactions { get; set; }
        }
        [HttpPost]
        public ActionResult React(string react)
        {
            int videoid = Convert.ToInt32(TempData["videoid"]);
            int userid = Convert.ToInt32(Session["LoggedAccountID"]);
            if (react != string.Empty)
            {
                reaction.Insert(react, userid, videoid);
            }
            return RedirectToAction("Index", new {id = videoid});
        }

        public ActionResult Like()
        {
            try
            {
                Feedback feedback = new Feedback(1, 0, Convert.ToInt32(Session["LoggedAccountID"]),
                    Convert.ToInt32(TempData["videoid"]));
                video.InsertFeedback(feedback);
                return RedirectToAction("Index", new {id = Convert.ToInt32(TempData["videoid"])});
            }
            catch
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(TempData["videoid"]) });
            }

        }
        public ActionResult DisLike()
        {
            try
            {
                Feedback feedback = new Feedback(0, 1, Convert.ToInt32(Session["LoggedAccountID"]),
                    Convert.ToInt32(TempData["videoid"]));
                video.InsertFeedback(feedback);
                return RedirectToAction("Index", new { id = Convert.ToInt32(TempData["videoid"]) });
            }
            catch
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(TempData["videoid"]) });
            }

        }


    }
}