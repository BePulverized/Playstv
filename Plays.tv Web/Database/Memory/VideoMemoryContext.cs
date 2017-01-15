using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plays.tv_App;
using Plays.tv_App.Database;

namespace Plays.tv_Web.Database.Memory
{
    public class VideoMemoryContext:IVideoContext
    {
        public List<Video> videos = new List<Video>()
        {
            new Video(0, new User(0, "jordy", "jordy150@gmail.com", "hoi123", "bepulverized", ""), 0 , "testvideo1", new Category("MOBA", 0),new Feedback(0,0), new Game(0, "League of legends")),
            new Video(1, new User(0, "jordy", "jordy150@gmail.com", "hoi123", "bepulverized", ""), 0 , "testvideo2", new Category("MOBA", 0), new Feedback(0,0),new Game(0, "League of legends")),
            new Video(2, new User(1, "Jeroen", "jeroen@gmail.com", "hoi123", "bossintraining", ""), 0 , "testvideo3", new Category("MOBA", 0), new Feedback(0,0),new Game(0, "League of legends")),
            new Video(3, new User(1, "Jeroen", "jeroen@gmail.com", "hoi123", "bossintraining", ""), 0 , "testvideo4", new Category("MOBA", 0), new Feedback(0,0),new Game(0, "League of legends"))

        };

        public List<Feedback> feedbacklist = new List<Feedback>()
        {
            new Feedback(0,0, 0, 0),
            new Feedback(0,0, 0, 0),
            new Feedback(0,0, 1, 1),
            new Feedback(0,0, 1, 1),

        };
        public bool Insert(Video insertvideo)
        {
            Video returnvideo = null;
            foreach (Video video in videos)
            {
                if (video.ID != insertvideo.ID)
                {
                    videos.Add(insertvideo);
                    return true;
                }
            }
            return false;
        }

        public List<Video> GetVideosByUser(User user)
        {
            List<Video> returnList = new List<Video>();
            foreach (Video video in videos)
            {
                if (video.Author.ID == user.ID)
                {
                    returnList.Add(video);
                }
            }
            return returnList;
        }

        public List<Video> GetRecentVideos()
        {
            List<Video> returnlist = new List<Video>();
            returnlist.Add(videos[videos.Count]);

            return returnlist;
        }

        public Video GetVideo(int id)
        {
            Video returnvVideo = null;
            foreach (Video video in videos)
            {
                if (video.ID == id)
                {
                    returnvVideo = video;
                }
            }
            return returnvVideo;
        }

        public List<Video> SearchVideos(string search)
        {
            List<Video> returnlist = new List<Video>();
            foreach (Video video in videos)
            {
                if (video.Title == search)
                {
                    returnlist.Add(video);
                }
            }
            return returnlist;
        }

        public bool InsertFeedback(Feedback feedback)
        {
            feedbacklist.Add(feedback);
            return true;
        }

        public bool View(int id)
        {
            throw new NotImplementedException();
        }
    }
}