using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App.Database
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

        public List<Video> GetAll()
        {
            return videos;
        }

        public List<Video> GetVideosbyGame(Game game)
        {
            throw new NotImplementedException();
        }

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

        public bool Update(Video video)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAllVideosReactions()
        {
            throw new NotImplementedException();
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
    }
}
