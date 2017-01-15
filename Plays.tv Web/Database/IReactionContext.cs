using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App.Database
{
    public interface IReactionContext
    {
        List<Reaction> GetReactionsbyVideo(int id);
        
        bool Insert(string reaction, int accountid, int videoid);
    }
}
