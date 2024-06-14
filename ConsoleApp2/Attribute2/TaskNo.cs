using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Attribute2
{
    public class TaskNoAttribute : Attribute
    {
        public TaskNoAttribute(string alias)
        {
            this.Alias = alias;
        }

        public string Alias;
    }

    public enum TaskList
    {
        [TaskNo("shanjing")]
        Start,
        [TaskNo("jingshan")]
        InWork
    }

    public class TestWork : BaseSingleton<TestWork>
    {
        List<Student> stds = new List<Student>() { new Student("shanjing", 18), new Student("limeng", 18) };

        Dictionary<int, List<Student>> s = new Dictionary<int, List<Student>>();

        public override void Test()
        {
            ////TaskList.Start.
            //Student ii = test111();
            //Console.WriteLine(test111().age);
            //ii.age = 20;

            //Console.WriteLine(test111().age);
            s.Add(1, new List<Student>());

            s[1] = stds;
            s[1].Add(new Student("shanjing1", 18));
            Console.WriteLine(JsonConvert.SerializeObject(s));

            
        }

        Student test111()
        {
            return stds[1];

        }

    }

    public class Student
    {

        public string name;

        public int age;

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
