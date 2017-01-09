using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Views { get; set; }
        public List<Video> AllVideos { get; set; }

        public Game(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public void AddVideo(Video video)
        {
            AllVideos.Add(video);
            Views = Views + video.Views;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
