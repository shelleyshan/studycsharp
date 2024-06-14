using ConsoleApp2.Script;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Tester
    {
        public static Tester Instance;

        public const double PI = 3.1416;
        public void CalculateSalary()
        {
            throw new System.NotImplementedException();
        }

        static Tester()
        { 
        Instance = new Tester();
        }

        public void TestCalculate()
        {
            //BaseCaculate baseCaculate;
            Console.WriteLine("请输入第一个数字：");
            string firstNumber = Console.ReadLine();

            Console.WriteLine("请输入第二个数字：");
            string secondNumber = Console.ReadLine();
            Console.WriteLine("请输入方法(+-*/)：");
            string function = Console.ReadLine();
            if (!string.IsNullOrEmpty(function))
            {
                //baseCaculate = BaseFactory.GetCalculateObject(function);
                //Console.WriteLine(baseCaculate.GetCalculate(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber)));
                Context context = new Context(function);
                Console.WriteLine(context.GetOperation(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber)));

            }

            int[] val2 = { 2, 3, 4 };
            ListInts(1, 2, 3);
            ListInts(val2);
        }

        void ListInts(params int[] inVals)
        { 
        
        }
    }

    public class TestWConst
    {
        public void wwww()
        {
            Console.WriteLine(Tester.PI);
        }
    }

    public class BaseClass
    {
        public int Id;
        public BaseClass(int id)
        {
            Id = id;
        }
    }

    public class BaseClass2 : BaseClass
    {
        public BaseClass2(int id) : base(id)
        {
        }
    }

    public class TestClass
    {
        public static void Test()
        {
            //BaseClass2 baseClass2 = new BaseClass2(2);
            //Console.WriteLine(baseClass2.Id);

            int[] a = { 1, 2, 3, 4 };
            int[] b = { 10, 20, 1 };

            var list = from x in a
                       from y in b
                       let s = x + y
                       where s > 20
                       select new { x, y, s };

            var list1 = from x in a
                        join y in b on x equals y

                        into xgroupb
                        from z in xgroupb
                        select z;

            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
        }

        public static void TestVirtual()
        { 
        Student student = new Student();
            student.TestVirtual();

            Person person = new Person();
            person.TestVirtual();

            Teacher teacher = new Teacher();
            teacher.TestVirtual();
        }
    }

    public abstract class AbstractClassTest {
        public void Test()
        {
            Console.WriteLine("1111");
        }
    }

}