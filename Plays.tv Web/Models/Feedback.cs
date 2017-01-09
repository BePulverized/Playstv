using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App
{
    public class Feedback
    {
        public int Like { get; set; }
        public int Dislike { get; set; }
        public int UserID { get; set; }
        public int VideoID { get; set; }

        public Feedback(int like, int dislike)
        {
            Like = like;
            Dislike = dislike;
        }

        public Feedback(int like, int dislike, int userId, int videoid)
        {
            Like = like;
            Dislike = dislike;
            UserID = userId;
            VideoID = videoid;
        }
    }
}
