using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plays.tv_App;
using Plays.tv_App.Database;

namespace Plays.tv_Web.Database.Memory
{
    public class ReactionMemoryContext:IReactionContext
    {
        public List<Reaction> reactions = new List<Reaction>()
        {
            new Reaction("test reaction", new User(0, "jordy", "jordy150@gmail.com", "hoi123", "bepulverized", ""), 0, 0),
            new Reaction("test reaction", new User(1, "jordy", "jordy150@gmail.com", "hoi123", "bepulverized", ""), 0, 1),
            new Reaction("test reaction", new User(2, "jordy", "jordy150@gmail.com", "hoi123", "bepulverized", ""), 0, 0),
            new Reaction("test reaction", new User(3, "jordy", "jordy150@gmail.com", "hoi123", "bepulverized", ""), 0, 0),

        };
        public List<Reaction> GetReactionsbyVideo(int id)
        {
            List<Reaction> returnlist = new List<Reaction>();
            foreach (Reaction reaction in reactions)
            {
                if (reaction.videoid == id)
                {
                    returnlist.Add(reaction);
                }
            }
            return returnlist;
        }

        public bool Insert(string reaction, int accountid, int videoid)
        {
            reactions.Add(new Reaction(reaction, new User(accountid, "jordy", "jordy150@gmailcom", "hoi123", "Bepulverized", ""), 0 ));
            return true;
        }
    }
}