using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.WeiQiGame
{
    public class Coordinate
    {
        private int x, y;
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
          

        }
        public int X { get { return x; } }

        public int Y { get { return y; } }
    }
}
