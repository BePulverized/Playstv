using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App.Database
{
    public interface IReactionContext
    {
        List<Reaction> GetAll();
        List<Reaction> GetReactionsbyVideo(Video video);
        Reaction Insert(Reaction reaction);
        bool Update(Reaction reaction);
        bool Delete(int id);
        Reaction GetByID(int id);
    }
}
