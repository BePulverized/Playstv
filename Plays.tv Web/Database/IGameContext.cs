using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App.Database
{
    public interface IGameContext
    {
        List<Game> GetAll();

        List<Category> GetAllCats();
    }
}
