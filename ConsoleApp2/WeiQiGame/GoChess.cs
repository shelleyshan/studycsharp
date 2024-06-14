
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.WeiQiGame
{
    public class GoChess
    {
        private ChessType color;
        public GoChess(ChessType color)
        {
            this.color = color;
        }

        public void Go(Coordinate coordinate)
        {
            Console.WriteLine($"{color.ToString()} 落子位置为{coordinate.X},{coordinate.Y}");

            CheckerBoard.Instance.SetChecker(color, coordinate.X - 1, coordinate.Y-1);
        }
    }
}
