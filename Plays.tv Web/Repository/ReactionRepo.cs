using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plays.tv_App.Database;

namespace Plays.tv_App.Controllers
{
    public class ReactionRepo
    {
        private IReactionContext context;
        public ReactionRepo(IReactionContext context)
        {
            this.context = context;
        }
        public List<Reaction> GetReactionsForVideo(int id)
        {
            return context.GetReactionsbyVideo(id);
        }

        public bool Insert(string text, int accountid, int videoid)
        {

            return context.Insert(text, accountid, videoid);
        }
    }
}
