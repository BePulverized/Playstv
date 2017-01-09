using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App.Database
{
    public interface IVideoContext
    {
        List<Video> GetAll();
        List<Video> GetVideosbyGame(Game game);
        Video Insert(Video video);
        bool Update(Video video);
        bool Delete(int id);

        List<Video> GetAllVideosReactions();

        List<Video> GetVideosByUser(User user);
    }
}
