
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.WeiQiGame
{
    public class GoChessFactory
    {
        private static Hashtable goChessHash = new Hashtable();

        private static GoChessFactory instance = new GoChessFactory();

        public static GoChessFactory Instance
        { get { return instance; } }

        private GoChessFactory()
        {

            goChessHash.Add("b", new GoChess(ChessType.Black));
            goChessHash.Add("w", new GoChess(ChessType.White));
        }

        public GoChess GetGoChess(string color)
        {
            if (goChessHash != null && goChessHash.ContainsKey(color))
            {
                return (GoChess)goChessHash[color];
            }
            else
            {
                return null;
            }
        }
    }

    public class Game : BaseSingleton<Game>
    {
        public void StartGame()
        {
            GoChess b1 = GoChessFactory.Instance.GetGoChess("b");
            b1.Go(new Coordinate(1, 3));
            GoChess w1 = GoChessFactory.Instance.GetGoChess("w");
            w1.Go(new Coordinate(2, 3));

            b1.Go(new Coordinate(1, 3));
            b1.Go(new Coordinate(3, 3));
            w1.Go(new Coordinate(2, 4));

           

            int i = 0;
            while (true)
            {
                GoChess goChess = null;
                if (i % 2 == 0)
                {
                    Console.WriteLine("轮到黑棋，请输入（横纵坐标使用英文逗号分割，如1,3）");

                    goChess = b1;   
                }
                else
                {
                    Console.WriteLine("轮到白棋，请输入（横纵坐标使用英文逗号分割，如1,3）");
                    goChess = w1;
                }
                var str = Console.ReadLine();


                if (str == "end")
                {
                    CheckerBoard.Instance.GetCurrentCheckerBoard();

                    Console.ReadLine();
                }
                else
                {
                    goChess.Go(GetCoordinate(str));
                    i++;
                }
            }
        }

        public override void Test()
        {
            throw new NotImplementedException();
        }

        private Coordinate GetCoordinate(string str)
        {
            Coordinate coordinate1 = null;
            if (!string.IsNullOrEmpty(str))
            {

                var arr = str.Split(',');
                if (arr.Length == 2)
                {
                    coordinate1 = new Coordinate(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]));
                }
            }
            return coordinate1;
        }
    }
}
