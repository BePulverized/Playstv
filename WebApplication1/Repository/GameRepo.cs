using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plays.tv_App.Database;

namespace Plays.tv_App.Controllers
{
    public class GameRepo
    {
        private IGameContext context;
        public GameRepo(IGameContext context)
        {
            this.context = context;
        }

        public List<Game> GetAll()
        {
            return context.GetAll();
        }

        public List<Category> GetAllCats()
        {
            return context.GetAllCats();
        }
    }
}
