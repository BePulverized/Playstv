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

        public Feedback(int like, int dislike)
        {
            Like = like;
            Dislike = dislike;
        }
    }
}
