using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Script
{
    public class TestActionParam
    {
        public static void Test(int param)
        {
            Console.WriteLine(param);
        }
        public static string name { get; set; }
        public static void TestActionManager(int param, Action<int> handle)
        {
            handle?.Invoke(param);
            Console.WriteLine($"name is {nameof(handle)}");
        }

        public static void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                TestActionManager(i, Test);
            }

        }


        public static void TestAction()
        {
            Console.WriteLine($"---开始执行{System.DateTime.Now.ToString()}---");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine($"----结束执行{System.DateTime.Now.ToString()}----");
        }
    }

}
