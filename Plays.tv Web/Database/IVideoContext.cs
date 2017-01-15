using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App.Database
{
    public interface IVideoContext
    {
        bool Insert(Video video);
       List<Video> GetVideosByUser(User user);
        List<Video> GetRecentVideos();
        Video GetVideo(int id);
        List<Video> SearchVideos(string search);
        bool InsertFeedback(Feedback feedback);
        bool View(int id);
        List<Video> GetAllVideos();

        List<Feedback> GetFeedback();

    }
}
