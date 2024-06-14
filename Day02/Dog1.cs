using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class Dog1 : IDog
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Dog1(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Shout()
        {Test01.Instance.Name = Name;
            
            Console.WriteLine($"this is Dog1 its name is{Name},  and it is {Age} years old");
        }


    }

    public class Test01
    {
        public string? Name { get; set; }
        public int Age { get; set; }

        public static Test01 Instance;
        static Test01()
        {
            if (Instance == null)
            { 
            Instance = new Test01();
            }
        }
        public string? NameBig { get; set; }
        public int Salary { get; set; }

        private Test01() { }    
    }
}
