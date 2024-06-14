using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Script
{

    public class Grammer : IGrammer01, IGrammer02, IComparable
    {
        public int ATK;
        public int ATKDistance;
        public int CompareTo(object? obj)
        {
            var objGrammer = obj as Grammer;
            if (objGrammer == null)
            {
                return -1;
            }
            else
            {
                return this.ATK.CompareTo(objGrammer.ATK);
            }
        }

        public void Fun1()
        {
            Console.WriteLine("实现接口");
        }

        public void Fun2()
        {
            Console.WriteLine("实现接口");
        }

        void IGrammer01.Fun1()
        {
            Console.WriteLine("显示实现01接口Fun1");
        }

        void IGrammer01.Fun2()
        {
            Console.WriteLine("显示实现01接口Fun2");
        }
    }


    public interface IGrammer01
    {
        void Fun1();
        void Fun2();
    }

    public interface IGrammer02
    {
        void Fun1();
        void Fun2();
    }

    public class ComplareType : IComparer<Grammer>
    {
        public int Compare(Grammer? x, Grammer? y)
        {
            return x.ATKDistance.CompareTo(y.ATKDistance);
        }
    }


    public static class TestGrammer
    {
        public static void Main()
        {
            IGrammer01 grammer01 = new Grammer();
            grammer01.Fun1();
            grammer01.Fun2();

            Grammer grammer02 = new Grammer();
            grammer02.Fun1();
            grammer02.Fun2();

            Grammer[] grammers = new Grammer[5] {
            new Grammer(){ ATK = 6, ATKDistance = 10  },
            new Grammer(){ ATK = 2, ATKDistance = 20  },
            new Grammer(){ ATK = 3, ATKDistance = 30  },
            new Grammer(){ ATK = 4, ATKDistance = 60  },
            new Grammer(){ ATK = 5, ATKDistance = 50  },
            };

            IComparer<Grammer> comparable = new ComplareType();
            Array.Sort(grammers, comparable);

            Console.WriteLine(JsonConvert.SerializeObject(grammers));

            MySort<Grammer>(grammers, (a, b) => { return a.ATK.CompareTo(b.ATK) > 0 ? true : false; });
        }
        /// <summary>
        /// 变化点：类型 依据
        /// 解决：  泛型 委托
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="compareFunc"></param>
        public static void MySort<T>(T[] array, Func<T, T, bool> compareFunc)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {

                    if (compareFunc(array[i], array[j]))
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }

                }
            }

        }

    }


    class HandEnumerator : IEnumerator
    {

        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }


    public static class Test0506
    {
        public static void TestStruct()
        {
            TimeArea timeArea = new TimeArea(TimeSpan.Parse("13:00:00"), TimeSpan.Parse("14:00:00"));

            List<TimeArea> timeAreas = new List<TimeArea>();
            timeAreas.Add(timeArea);

            var firsttime = timeAreas.FirstOrDefault(p =>
            {
                return System.DateTime.Now.TimeOfDay > p.endTime;
            });
            Console.WriteLine(firsttime.startTime);
            Console.WriteLine(TimeSpan.Parse("13:00:00"));
            Console.WriteLine(System.DateTime.Now.TimeOfDay);
            Console.WriteLine(TimeSpan.MinValue);

            Console.WriteLine(TimeSpan.Zero);

            var roomId = System.DateTime.Now.Ticks;

            DateTime dt = new DateTime(roomId);
            Console.WriteLine(dt.TimeOfDay);
        }

        public static void TestDive(int currentRoleType)
        {

            int diceType = currentRoleType % 10;//棋子骰子状态
            int chessType = currentRoleType / 10;//棋子出场特效

            Console.WriteLine($"diceType is {diceType}, chessType is {chessType}");

            float float1 = (float)currentRoleType / 10;

            int float2 = (int)(float)currentRoleType / 10;
            Console.WriteLine($"float2 is {float2}");
        }

        public struct TimeArea
        {
            public TimeSpan startTime;
            public TimeSpan endTime;

            public string info
            {
                get
                {
                    return $"{startTime.ToString(@"hh\:mm")}-{endTime.ToString(@"hh\:mm")}";
                }
            }

            public TimeArea(TimeSpan startTime, TimeSpan endTime)
            {
                this.startTime = startTime;
                this.endTime = endTime;
            }
        }
    }


    public static class TestRemove
    {
     static   List<Student> studentList = new List<Student>();

      static  List<int> ScoreList
        {
            get
            {
                return studentList.Select(p => p.Score).ToList();
    }
        }
        public static void Test()
        {
           
            studentList.Add(new Student() { Name = "zhansan", Score = 100 });
            studentList.Add(new Student() { Name = "lisi", Score = 90 });
            studentList.Add(new Student() { Name = "wangwu", Score = 80 });



          var list=   studentList.Where(p => p.Score >= 90).ToList();
          foreach (var item in list)
            {
                item.Score += 10000;
            }
          
            Console.WriteLine(JsonConvert.SerializeObject(studentList));

        }
    }
}

