 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Person
    {
        public string Name
        {
            get => default;
            set
            {
            }
        }

        public Person()
        {
            Console.WriteLine("调用父类构造函数");

        }

        public virtual void TestVirtual()
        {
            Console.WriteLine("this is virtual person function");
        }
    }
}