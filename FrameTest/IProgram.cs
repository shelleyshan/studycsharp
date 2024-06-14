using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FrameTest
{
    public interface IProgram
    {
        void Write();
    }

    public class ProgramTest : IProgram
    {
        public void Write()
        {
            Console.WriteLine("test");
        }

        public static void Test()
        {
            IProgram program = new ProgramTest1();
            program.Write();
        }



    }

    public class ProgramTest1 : IProgram
    {
        public string str;
        void IProgram.Write()
        {
            All.Test();
        }
    }

    interface IPeople
    {
        string Name { get; set; }
        string Gender { get; set; }
    }

    interface ITeacher : IPeople
    {
        float Salary { get; set; }

        void WriteT();
    }

    interface IStudent : IPeople
    {
        float Score { get; set; }
        void WriteS();

        Action TestAction { get; set; }

    }


    public class All : IPeople, ITeacher
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public float Salary { get; set; }
        public float Score { get; set; }



        public static void Test()
        {
            Type t = typeof(Test111);
            object[] AttArr = t.GetCustomAttributes(false);

            foreach (var item in AttArr)
            {
                MyAttributeAttribute myAttributeAttribute = item as MyAttributeAttribute;
                if (myAttributeAttribute != null)
                {
                    Console.WriteLine($"IntParam1 is {myAttributeAttribute.IntParam1}");
                    Console.WriteLine($"IntParam2 is {myAttributeAttribute.IntParam2}");
                }
            }
        }



        public void WriteS()
        {
            Console.WriteLine($"name is {Name}, gender is {Gender}, score is {Score}");
        }

        public void WriteT()
        {
            Console.WriteLine($"name is {Name}, gender is {Gender}, salary is {Salary}");
        }
    }


    public abstract class Shape
    {
        public string Color { get; set; }

        public Shape(string color)
        {
            Color = color;
        }

        public string GetColor()
        {
            return Color;
        }

        public abstract double GetArea();
    }

    public abstract class TestShape : Shape
    {
        public TestShape(string color) : base(color) { }
    }



    public class Rectangular : Shape
    {
        protected double Length, Width;
        public override double GetArea()
        {
            return (Length * Width);
        }

        public Rectangular(double length, double width, string color) : base(color)
        {
            Length = length;
            Width = width;
            Color = color;
        }

        public double PerimeterIs()
        {
            return 2 * (Length + Width);
        }
    }

    public class Circle : Shape
    {
        private double Radius;

        public Circle(double radius, string color) : base(color)
        {
            this.Radius = radius;
            this.Color = color;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Square : Rectangular
    {
        public Square(double side, string color) : base(side, side, color) { }
    }

    public class TestAbstractClass
    {
        public static void Test()
        {
            Circle circle = new Circle(1.2, "黄色");
            Console.WriteLine("圆形的颜色是{0},它的面积是{1}", circle.Color, circle.GetArea());
        }
    }

    public class MyClass1
    {
        public virtual void Test1()
        {
            Console.WriteLine("this is not sealed function");
        }
    }

    public class ExtendMyClass : MyClass1
    {
        public sealed override void Test1()
        {
            Console.WriteLine("this is sealed function");
        }

    }

    public sealed class MyAttributeAttribute : System.Attribute
    {
        public int IntParam1;
        public int IntParam2;

        public MyAttributeAttribute(int intParam1, int intParam2)
        {
            IntParam1 = intParam1;
            IntParam2 = intParam2;
        }
    }

    [MyAttribute(1, 2)]
    public class Test111
    {

       // public 

    }



    public class MyClass
    {
        
       public class MyCounter
        {
            public int Count { get; private set; }
            public static MyCounter operator ++(MyCounter current)
            {
                current.Count++;
                return current;
            }

           
        }
        private MyCounter counter;
        public MyClass() { counter = new MyCounter(); }
        public int Incr() { return (counter++).Count; }
        public int GetValue() { return counter.Count; }

    }

}

