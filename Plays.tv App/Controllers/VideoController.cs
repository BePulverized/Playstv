using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plays.tv_App.Database;

namespace Plays.tv_App.Controllers
{
    public class VideoController
    {
        // Deze klasse connect de forms met de database. Eventuele correcties na of voor database worden hier ook gedaan.
        private IVideoContext context;
        public VideoController(IVideoContext context)
        {
            this.context = context;
        }

        public List<Video> GetVideosByUser(User user)
        {
            return context.GetVideosByUser(user);
        }

        public Video Insert(Video video)
        {
            return context.Insert(video);
        }
    }
}
