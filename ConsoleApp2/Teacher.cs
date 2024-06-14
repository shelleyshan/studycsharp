using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Teacher : Person
    {
        public float Salary
        {
            get => default;
            set
            {
            }
        }

        public Teacher()
        {
            this.Salary = 0.5f;
        }

        public override void TestVirtual()
        {
            base.TestVirtual();
            Console.WriteLine("this is teacher override function");
        }
    }
}