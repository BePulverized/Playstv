using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App
{
    public class Reaction
    {
        public string Text { get; set; }
        public User User { get; set; }
        public int ParentId { get; set; }
        public int videoid { get; set; }

        public Reaction(string text, User user, int parentId)
        {
            Text = text;
            User = user;
            ParentId = parentId;
        }

        public Reaction(string text, User user, int parentId, int videoid)
        {
            Text = text;
            User = user;
            ParentId = parentId;
            this.videoid = videoid;
        }
    }
}
