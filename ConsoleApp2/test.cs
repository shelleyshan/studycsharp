using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp2
{
    public class BaseTest
    {
        public string name
        {
            get => default;
            set
            {
            }
        }

        public void Write()
        {
            Console.WriteLine("This is base function");
        }

        public virtual void WriteLine()
        {
            Console.WriteLine("This is virtual base function");
        }
    }

    public class DerivedTest:BaseTest
    {
        new public void Write()
        {
            Console.WriteLine("This is derived function");
        }

        public override void WriteLine()
        {
            base.WriteLine();

            Console.WriteLine("This is override derived function");
        }
    }

    public class SecondDerivedTest:DerivedTest
    {
        public  void WriteLine()
        {
            Console.WriteLine("This is second derived function");
        }
    }

    public class MainClass
    {
        public delegate void MainClassDelegate();

        public static void deleFunc()
        {
            Console.WriteLine("this is delegate function");
        }
        public static void Test()
        {
            //BaseTest test = new SecondDerivedTest();

            //    test.Write();
            //    test.WriteLine();

            //MainClassDelegate del = deleFunc;
            //del += () => {
            //    Console.WriteLine("this is function 2");
            //};
            //del.Invoke();

            Incrementer incrementer = new Incrementer();
            Dozens dozens = new Dozens(incrementer);
            incrementer.DoCount();
            Console.WriteLine(dozens.DozensCount);

        }
    }


    public class Incrementer
    {
        public event EventHandler CountedADozen; //

        public void DoCount()
        {

            for (int i = 0; i < 100; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                    CountedADozen(null, null);
            }

        }
    }

    public class Dozens
    { 
    public int DozensCount { get;private set; }
        public Dozens(Incrementer incrementer)
        {
            DozensCount = 0;
            incrementer.CountedADozen += DozensCountHandler;
        }

        private void DozensCountHandler(object? sender, EventArgs e)
        {
            DozensCount++;
        }
    }

}