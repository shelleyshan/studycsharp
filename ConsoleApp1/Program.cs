

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    delegate long MyDel(int first, int second);
    internal class Program
    {
        static long Sum(int x, int y)
        {
            Console.WriteLine("-----------------begin wait -----------------");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~test~~~~~~~~~~~~~~~~~~~~~~~");
            Thread.Sleep(1000);
            return x + y;
        }


        static void Main()
        {
            //MyDel mydel = new MyDel(Sum);
            //Console.WriteLine("begin begininvoke");
            //Debug.WriteLine("1111");
            //long rst = mydel.Invoke(4, 6);
            //IAsyncResult iar = mydel.BeginInvoke(14, 6, null, null);


            //Console.WriteLine("after begininvoke");

            //Console.WriteLine(rst);
            //long rs = mydel.EndInvoke(iar);
            //Console.WriteLine(rs.ToString());

            //long nowTicks = DateTime.Now.Ticks;

            //  // ticks转换为DateTime
            //  DateTime dt = new DateTime(nowTicks);
            //  Console.WriteLine(dt.ToString());



            //roomInfo room = new roomInfo();
            //room.roomid = 10001;
            //room.userList = new List<UserInfo>();
            //for (int i = 0; i < 4; i++)
            //{
            //    room.userList.Add(new UserInfo()
            //    {
            //        uid = i,
            //        uname = "name" + i
            //    });
            //}

            //var userinfo = getUserInfo(1, room);
            //userinfo.uname = "testname";


            //TestRoomInfo(room);
            //Console.WriteLine(JsonConvert.SerializeObject(room));
            //Console.ReadLine();
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(long.MaxValue);
            Console.WriteLine(double.MaxValue);

            Console.WriteLine(Convert.ToDateTime("2022-11-1 00:00:00"));



            Console.WriteLine(new System.DateTime(DateTime.Now.Ticks));

            Console.WriteLine(new System.DateTime(DateTime.Now.Ticks + 100000000).ToString());
            Console.WriteLine(Convert.ToInt64(TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds));
            DateTime time = DateTime.Now;
            Dictionary<long, int> testscore = new Dictionary<long, int>() { { 1, 5 }, { 2, 9 }, { 3, 5 }, { 4, 1 }, { 5, 81 }, { 6, 81 } };
            Dictionary<long, DateTime> testtime = new Dictionary<long, DateTime>() { { 1, time }, { 2, time.AddDays(-1) }, { 3, time.AddDays(1) }, { 4, time }, { 5, time.AddDays(5) }, { 6, time.AddDays(-5) } };

            SortedDictionary<string, long> score = new SortedDictionary<string, long>();

            var keys = testscore.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                var v = string.Format("{0:D6}", testscore[keys[i]]) + string.Format("{0:D9}", Convert.ToInt32(testtime[keys[i]].Subtract(Convert.ToDateTime("2022-11-1 00:00:00")).TotalSeconds));
                score.Add(v, keys[i]);
            }
            Console.WriteLine(String.Join(",", score.Values));
            Console.WriteLine(String.Join(",", score.Keys));
            score = new SortedDictionary<string, long>();
            for (int i = 0; i < keys.Count; i++)
            {
                var v = string.Format("{0:D6}", (999999 - testscore[keys[i]])) + String.Format("{0:D9}", Convert.ToInt32(999999999 - testtime[keys[i]].Subtract(Convert.ToDateTime("2022-11-1 00:00:00")).TotalSeconds));
                score.Add(v, keys[i]);
            }
            Console.WriteLine(String.Join(",", score.Values));
            Console.WriteLine(String.Join(",", score.Keys));
            Console.WriteLine(String.Join(",", score.Keys.Select(p => Convert.ToDouble(p))));
            Console.ReadLine();
        }

        //private static void TestRoomInfo(roomInfo room)
        //{
        //    roomInfo newRoom = new roomInfo();
        //    newRoom.roomid = room.roomid;
        //    newRoom.userList = room.userList.Select(p => new UserInfo { uid = p.uid + 1, uname = p.uname + "_test" }).ToList();

        //    Console.WriteLine(JsonConvert.SerializeObject(newRoom));
        //}

        //public static UserInfo getUserInfo(int uid, roomInfo roominfo)
        //{
        //    return roominfo.userList.Find(p => p.uid == uid);
        //}

        // public static List<T> stringtoOther()

        //static void Main(string[] args)
        //{
        //    MyClass myClass1 = new MyClass();
        //    IMyIfc<int> intIfc1 = myClass1;

        //    var test = intIfc1 as MyClass;
        //    test.PrintOut("11111");

        //    MyTestClass myClass2 = new MyTestClass();
        //    IMyIfc<int> intIfc2 = myClass2;
        //    var test1 = intIfc2 as MyClass;

        //    if (test1 != null)
        //    {
        //        test1.PrintOut("11111");
        //    }

        //    var test2 = intIfc2 as MyTestClass;
        //    if (test2 != null)
        //    {
        //        test2.PrintOut("11111");
        //    }

        //    Console.Read();
        //}



    }
}

//    class UserInfo
//    {
//        public int uid;
//        public string uname;
//    }

//    class roomInfo
//    {
//        public int roomid;
//        public List<UserInfo> userList;
//    }

//    interface IIfc1 { void PrintOut(string s); }
//    interface IIfc2 { void PrintOut(string s); }

//    interface IDerive : IIfc2
//    { }

//    class MyClass : IDerive, IMyIfc<int>
//    {
//        public int IPrintOut(int s)
//        {
//            throw new NotImplementedException();
//        }


//        public void PrintOut(string s)
//        {
//            Console.WriteLine(s);
//        }

//    }

//    class MyTestClass : IDerive, IMyIfc<int>
//    {
//        public int IPrintOut(int s)
//        {
//            throw new NotImplementedException();
//        }


//        public void PrintOut(string s)
//        {
//            Console.WriteLine("test" + s);
//        }
//    }
//    public delegate TR Func<T1, T2, TR>(T1 p1, T2 p2);
//    class MyClass1
//    {
//        public void test()
//        {

//            int[] numbers = { 2, 3, 4, 5, 6, 8 };
//            int[] numbers1 = { 3, 4, 5, 8 };

//            var numbers2 = from n in numbers join s in numbers1 on n equals s select new { n, sum = n + s };

//            var test = from n in numbers join m in numbers1 on n equals m let sum = n + m select new { sum };


//            var students = new[] { new { name = "1", project = "yuwen" }, new { name = "2", project = "yuwen" }, new { name = "3", project = "shuxue" } };

//            var sss = from s in students group s by s.project;

//            foreach (var item in sss)
//            {
//                Console.WriteLine(item.Key);
//                foreach (var s in item)
//                {
//                    Console.WriteLine($"{s.name},{s.project}");
//                }
//            }

//            //foreach (var item in numbers2)
//            //{
//            //    Console.WriteLine($"{item.n},{item.sum}");
//            //}
//        }
//    }

//    interface IMyIfc<T>
//    {
//        T IPrintOut(T s);
//    }
//}


/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    class Animal
    {
        public virtual void eat()
        {
            Console.WriteLine("Animal eat!");
        }
        public void sleep()
        {
            Console.WriteLine("Animal sleep!");
        }
    }

    class Cat : Animal
    {
        public override void eat()
        {
            base.eat();
            Console.WriteLine("Cat eat!");
        }

        public new void sleep()
        {
            Console.WriteLine("Cat sleep!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat c = new Cat();
            c.eat();
            c.sleep();
            Animal cat = new Cat();
            cat.eat();
            cat.sleep();

            Console.ReadLine();

        }

    }
}

*/