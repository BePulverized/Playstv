using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App
{
    public class Category
    {
        public string Name { get; set; }
        public int Views { get; set; }

        public Category(string name, int views)
        {
            Name = name;
            Views = views;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
