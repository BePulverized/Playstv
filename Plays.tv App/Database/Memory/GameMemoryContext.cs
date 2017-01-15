using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App.Database
{
    public class GameMemoryContext:IGameContext
    {
        private List<Game> games = new List<Game>()
        {
            new Game(0, "League of legends"),
            new Game(1, "Overwatch"),
            new Game(2, "Call of duty")
        };

        private List<Category> cats = new List<Category>()
        {
            new Category("MOBA", 2000),
            new Category("FPS", 4000),
            new Category("Horror", 1000)
        };
        public List<Game> GetAll()
        {
            return games;
        }

        public List<Category> GetAllCats()
        {
            return cats;
        }
    }
}
