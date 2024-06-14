using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.WeiQiGame
{
    public class CheckerBoard
    {
        public static CheckerBoard Instance = new CheckerBoard();

        private CheckerBoard() { }

        public int[,] CheckerBoardArray = new int[13, 13];

        public void SetChecker(ChessType chess, int x, int y)
        {

            if (CheckerBoardArray[x, y] > 0)
            {
                Console.WriteLine("这里有棋，不可落子");
                return;
            }

            CheckerBoardArray[x, y] = (int)chess;


        }

        public void GetCurrentCheckerBoard()
        {
            for (int i = 0; i < CheckerBoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < CheckerBoardArray.GetLength(1); j++)
                {
                    string s = GetChessOuput(i, j);
                    Console.Write(s);
                }
                Console.WriteLine();
            }

        }

        private string GetChessOuput(int i, int j)
        {
            return CheckerBoardArray[i, j] == 0 ? "-" : CheckerBoardArray[i, j] == (int)ChessType.Black ? "*" : "@";
        }
    }

    public enum ChessType
    {
        Black = 1, White = 2,
    }



}
