using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Student : Person
    {
        public int Score
        {
            get;
            set;
            
        }

        public Student()
        {
            Console.WriteLine("调用子类构造函数");
        }

        public void TestVirtual()
        {
            Console.WriteLine("This is student new function");
        }
    }
}