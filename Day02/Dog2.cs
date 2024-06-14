using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class Dog2 : IDog
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Dog2(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Shout()
        {
            Console.WriteLine($"this is Dog2 its name is{Name},  and it is {Age} years old");
        }

        public static void Main()
        { }
    }
}
