using Google.Protobuf.WellKnownTypes;
using LoadBalancingClientFrame;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Paddings;
using ProtoBuf;
using ProtoBufUtilsFrame.UtilsFrame;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WemakeBaseFrame;
using WemakeDataCacheFrame;
using WemakeRedisFrame;
using Random = WemakeBaseFrame.Random;

namespace Script
{



    class LandData
    {
        public long owner;
        public int id;
    }

    class TestClass1
    {
        public float F1;
        public float F2;
        public float F3;
        public TestClass1(float f1, float f2, float f3)
        {
            F1 = f1;
            F2 = f2;
            F3 = f3;
        }

        public float Sum()
        {
            return F1 + F2 + F3;
        }
    }

    static class ExtendTestClass1
    {
        public static float Average(this TestClass1 test, float f1, float f2)
        {
            return (f1 + f2) / 3;
        }
    }

    static class TestEvent
    {

        public static void Test1()
        {
            Publisher p = new Publisher();
            Subscriber s = new Subscriber();
            //p.simpleEvent += s.MethodA;
            // p.simpleEvent += s.MethodB;
            p.RaiseTheEvent();
            // p.simpleEvent -= s.MethodA;
            p.RaiseTheEvent();
            // p.simpleEvent -= s.MethodB;
            p.RaiseTheEvent();
        }

        public static void Test2()
        {
            int[] testarr = { 1, 2, 3 };
            bool is4 = testarr.Any(p => p == 4);

            bool is1 = testarr.Any(p => p == 1);

            var type1 = is1.GetType();
            var type2 = typeof(bool);


            Console.WriteLine(is4);
            Console.WriteLine(is1);


            Console.WriteLine(GetMethodName());

            Test3333();
        }

        public static void Test3()
        {
            List<int> list1 = new List<int> { 1, 2, 3 };
            List<int> list2 = new List<int> { 1, 2, 5 };
            var list3 = list2.Except(list1);
            Console.WriteLine(JsonConvert.SerializeObject(list3));

        }

        public static void Test4()
        {
            List<int> list2 = new List<int> { 1, 2, 5, 6, 7, 9, 10, 11 };

            for (int i = 0; i < list2.Count; i++)
            {
                Console.WriteLine(list2[i]);
            }

        }

        public static void Test10()
        {
            List<LandData> targetlandList = new List<LandData>();
            for (int i = 0; i < 10; i++)
            {
                targetlandList.Add(new LandData()
                {
                    owner = i % 3 + 1,
                    id = i + 1
                });
            }
            var targeUidList = targetlandList.Select(p => p.owner).Distinct().ToList();

            var ownerLandDic = new Dictionary<long, int>();

            foreach (var uid in targeUidList)
            {
                ownerLandDic.Add(uid, targetlandList.Where(p => p.owner == uid).Count());
            }

            int maxLandCount = ownerLandDic.Values.Max();
            var targetuids = ownerLandDic.Where(p => p.Value == maxLandCount).Select(p => p.Key).ToList();
            int minLandCount = ownerLandDic.Values.Min();
            var targetuid1s = ownerLandDic.Where(p => p.Value == minLandCount).Select(p => p.Key).ToList();
            //Error: var ownerLandDic = landList.ToDictionary(p => p.owner, p => landList.Where(s => s.owner == p.owner).Count());

            Console.WriteLine(JsonConvert.SerializeObject(targetuids));
            Console.WriteLine(JsonConvert.SerializeObject(targetuid1s));
        }

        public static void Test11()
        {
            TestClass1 test = new TestClass1(1, 2, 3);
            Console.WriteLine(test.Average(2, 7));

            Console.WriteLine(System.DateTime.Now.Date);
        }

        public static void Test12()
        {
            long rank = -2;
            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                string wcKey = RDB_Master.WinCountRanking + 1;
                rank = redisManager[RedisDBName.Master].CacheRedis.SortedSetRank(wcKey, 1000002572, Order.Descending, CommandFlags.None) ?? -2;
            });
            Console.WriteLine(rank);
        }
        public static void Test3333()
        {

            Console.WriteLine(nameof(Test3333));
            Console.WriteLine(nameof(Test4));
            Console.WriteLine(nameof(GetMethodName));
        }

        public static string GetMethodName()
        {
            MethodBase method = new System.Diagnostics.StackTrace().GetFrame(0).GetMethod();
            String className = method.ReflectedType.FullName;
            //方法名
            return method.Name;
        }

        internal static void Test5()
        {
            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                long uid = (long)redisManager["Account"].CacheRedis.HashGet("Account", "121212121");
            });
        }

        internal static void Test6()
        {
            Console.WriteLine(String.Format("{0:D2}", 1));
        }

        internal static void Test9()
        {
            List<A> listA = new List<A>();
            for (int i = 0; i < 6; i++)
            {
                listA.Add(new A() { id = i + 1, name = "name" + i + 1 });
            }



            int? id = GetModelA(listA, 9)?.id;



            Console.WriteLine(JsonConvert.SerializeObject(listA));
        }

        static A GetModelA(List<A> listA, int uid)
        {
            return listA.Find(p => p.id == uid);
        }

        internal static void Test8()
        {
            var dic = new Dictionary<string, int>();
            dic.Add("12334", 1);
            ABC abcmodel = new ABC(dic);
            abcmodel.Test();

            Console.WriteLine(JsonConvert.SerializeObject(abcmodel.FieldCountDic));
        }
    }

    class A
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ABC
    {
        private Dictionary<string, int> fieldCountDic;
        public Dictionary<string, int> FieldCountDic
        {
            get
            {
                return fieldCountDic;
            }
        }

        public Dictionary<string, int> GetFieldCountDic()
        {
            return fieldCountDic;
        }

        public ABC(Dictionary<string, int> fieldCountDic)
        {
            this.fieldCountDic = fieldCountDic;
        }

        public void Test()
        {
            //FieldCountDic = new Dictionary<string, int>();
            GetFieldCountDic().Add("123", 1);
        }
    }

    public abstract class TestAbstractClass
    {
        public abstract void Test();
        public void test1()
        {
            return;
        }

        public abstract void Test2();
        public void Test22(int p1, int p2)
        { }
    }
    public abstract class ExtendClass : TestAbstractClass
    {

    }

    public class MyClass1 : TestAbstractClass
    {
        public override void Test()
        {
            throw new NotImplementedException();
        }

        public override void Test2()
        {
            throw new NotImplementedException();
        }
    }

    public class MyClass2 : TestAbstractClass
    {
        public override void Test()
        {
            throw new NotImplementedException();
        }

        public override void Test2()
        {
            throw new NotImplementedException();
        }
    }

    class SomeClass
    {
        public SomeClass()
        {
            Console.WriteLine("some constructor");
        }
        public string Field1;

        public virtual void Print()
        {
            Console.WriteLine("some class");
        }
    }

    class OtherClass : SomeClass
    {
        int field1;
        public OtherClass()
        {
            Console.WriteLine("other constructor");
        }
        public OtherClass(int field1)
        {
            this.field1 = field1;
            Console.WriteLine($"other is {this.field1}");
        }

        new public string Field1 { get { return base.Field1; } }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("other class");
        }
    }
    class SecondOtherClass : OtherClass
    {
        public SecondOtherClass(int p1) : base(p1)
        {
            Console.WriteLine($"second is {p1}");
            Console.WriteLine("second constructor");
        }

        public SecondOtherClass()
        { }
        new public void Print()
        {
            base.Print();
            Console.WriteLine("second other class");
        }
    }

    public static class TestDerive
    {
        public static void Test1()
        {
            OtherClass other = new OtherClass();
            SomeClass some = other;
            some.Print();
            Console.WriteLine("----------");
            SecondOtherClass second = new SecondOtherClass();
            some = second;
            some.Print();


        }

        public static void Test2()
        {
            List<long> uids = new List<long>();
            uids.Remove(11111);
            Console.WriteLine(11111);
        }
    }


    public class Publisher
    {
        public event EventHandler SimpleEvent;
        public void RaiseTheEvent()
        {
            SimpleEvent(this, null);

        }
    }

    public class Subscriber
    {
        public void MethodA(object o, EventArgs e) { Console.WriteLine("AAA"); }
        public void MethodB(object o, EventArgs e) { Console.WriteLine("BBB"); }
    }


    public class Program
    {
        static void Main()
        {
            Publisher p = new Publisher();
            Subscriber s = new Subscriber();

            p.SimpleEvent += s.MethodA;
            p.SimpleEvent += s.MethodB;

            p.RaiseTheEvent();


        }
    }


    public interface IIfc1
    {
        public void Shout();
    }

    public interface IIfc2
    {
        public void Fly();
    }

    public class BaseA
    {
        public void dsdsdsd() { }
    }

    public class A1 : BaseA, IIfc1
    {
        public void Shout()
        {
            Console.WriteLine("AAAAAAAAAA");
        }

        public void A1Test()
        {
            Console.WriteLine("A1TEst");
        }
    }
    public class B1 : BaseA, IIfc1
    {
        public void Shout()
        {
            Console.WriteLine("BBBBBBBBBBBBB");
        }
    }

    public class C1 : BaseA, IIfc2
    {
        public void Fly()
        {
            Console.WriteLine("CCFly");
        }
    }

    public class Test11
    {
        public static void Test1()
        {
            BaseA[] basea = new BaseA[3];
            basea[0] = new A1();
            basea[1] = new B1();
            basea[2] = new C1();



            foreach (var item in basea)
            {
                IIfc1 iitem = item as IIfc1;
                if (iitem != null)
                {
                    iitem.Shout();
                }

                IIfc2 iitem1 = item as IIfc2;
                if (iitem1 != null)
                {
                    iitem1.Fly();
                }
            }
        }
    }

    public class BaseTest
    {
        public string name;
        public int id;
        public int groupid;
        public BaseTest(string name, int id, int groupid)
        {
            this.name = name;

            this.id = id;

            this.groupid = groupid;
        }

        public InnerBase InnerBase { get; set; }
    }

    [ProtoContract]
    public class InnerBase
    {
        [ProtoMember(1)]
        public int innerId;
        [ProtoMember(2)]
        public string innerName;

        public InnerBase(int innerId, string innerName)
        {
            this.innerId = innerId;
            this.innerName = innerName;
        }

        public InnerBase()
        {

        }
    }


    public class PBaseTest
    {
        public static List<BaseTest> staticBaseList = new List<BaseTest>() {
        new BaseTest("name1",1,1),
         new BaseTest("name2",2,1),
          new BaseTest("name3",3,2),
           new BaseTest("name4",4,2),
            new BaseTest("name5",5,3),
             new BaseTest("name6",6,3),
              new BaseTest("name7",7,3),
        };
        public static void TestDictionary()
        {
            Dictionary<string, List<BaseTest>> settings = new Dictionary<string, List<BaseTest>>();


        }

        public static void TestGroupBy()
        {
            var rlist = new List<BaseTest>();
            var list = staticBaseList.GroupBy(p => p.groupid);
            foreach (var item in list)
            {
                Console.WriteLine(item.Count());

                item.ToList().ForEach(r => r.name = "changename");
                rlist.Add(item.ToArray()[Random.Next(item.Count())]);
            }


            Console.WriteLine(JsonConvert.SerializeObject(rlist));
        }

        public static BaseTest GetBaseTest(Dictionary<string, List<BaseTest>> settings, int id)
        {
            BaseTest bst = null;
            if (settings.ContainsKey("name"))
            {
                bst = settings["name"].Find(p => p.id == id);
            }

            return bst;
        }
    }
    public class InnerBase1
    {
        [ProtoMember(1)]
        public int innerId;
        [ProtoMember(2)]
        public string innerName;

        public InnerBase1(int innerId, string innerName)
        {
            this.innerId = innerId;
            this.innerName = innerName;
        }

        public InnerBase1()
        {

        }
    }

    public class TestStaticInstance
    {
        public static TestStaticInstance Instance;

        public event Action Action;
        static TestStaticInstance()
        {
            Instance = new TestStaticInstance();
        }
        public void Test()
        {

            int mapId = 101;
            int mapType = 1;

            int matchType = 2;//1：单人对局 2：组队对局

            int matchResult = 1;//1：胜利 2：失败



            int[] mapIdArray = { mapId, -1 };
            int[] mapTypeArray = { mapType };
            int[] matchTypeArray = { matchType, -1 };
            int[] matchResultArray = { matchResult, -1 };

            int[][] array = new int[12][];
            int m = 0;
            for (int i = 0; i < mapIdArray.Length; i++)
            {
                for (int j = 0; j < matchTypeArray.Length; j++)
                {
                    for (int k = 0; k < matchResultArray.Length; k++)
                    {
                        int[] innerArray = { mapIdArray[i], matchTypeArray[j], matchResultArray[k] };
                        array[m] = innerArray;
                        m++;
                    }
                }
            }


            for (int i = 0; i < mapTypeArray.Length; i++)
            {
                for (int j = 0; j < matchTypeArray.Length; j++)
                {
                    for (int k = 0; k < matchResultArray.Length; k++)
                    {
                        int[] innerArray = { mapTypeArray[i], matchTypeArray[j], matchResultArray[k] };
                        array[m] = innerArray;
                        m++;
                    }
                }
            }

            Console.WriteLine(array.GetLength(0));

            Console.WriteLine(JsonConvert.SerializeObject(array));
        }

        static List<BaseTest> baseTestList = new List<BaseTest>();
        static List<InnerBase> staticInnerBaseTestList = new List<InnerBase>();


        public void InnerBaseTest()
        {
            InnerBase innerbase = new InnerBase() { innerId = 1, innerName = "name1" };
            var str = ProtoBufUtils.Serialize(innerbase);

            Console.WriteLine(str);

            var ss = ProtoBufUtils.Deserialize<InnerBase>(str);

            InnerBase1 innerbase1 = new InnerBase1(1, "name1");
            var strr = JsonConvert.SerializeObject(innerbase1);
            var newInner = JsonConvert.DeserializeObject<InnerBase1>(strr);

            DateTime dateTime = DateTime.Now;
            DateTime dateTime1 = dateTime.AddDays(-1);
            Console.WriteLine((dateTime - dateTime1).TotalDays);
        }


        public TestStaticInstance()
        {
            baseTestList.Add(new BaseTest("name1", 1, 1) { InnerBase = new InnerBase() { innerId = 1001, innerName = "innername1" } });
            baseTestList.Add(new BaseTest("name2", 2, 1) { InnerBase = new InnerBase() { innerId = 1002, innerName = "innername2" } });
            baseTestList.Add(new BaseTest("name3", 3, 2) { InnerBase = new InnerBase() { innerId = 1003, innerName = "innername3" } });
            baseTestList.Add(new BaseTest("name4", 4, 3) { InnerBase = new InnerBase() { innerId = 1004, innerName = "innername4" } });
            baseTestList.Add(new BaseTest("name5", 5, 3) { InnerBase = new InnerBase() { innerId = 1005, innerName = "innername5" } });

            staticInnerBaseTestList.Add(new InnerBase() { innerId = 1001, innerName = "innername1" });
            staticInnerBaseTestList.Add(new InnerBase() { innerId = 1002, innerName = "innername2" });
            staticInnerBaseTestList.Add(new InnerBase() { innerId = 1003, innerName = "innername3" });

        }

        public void TestChangeBaseTest()
        {
            List<BaseTest> changeBaseTestList = new List<BaseTest>();
            changeBaseTestList.Add(new BaseTest("changename1", 101, 1) { InnerBase = new InnerBase() { innerId = 1001, innerName = "innername1" } });
            changeBaseTestList.Add(new BaseTest("changename2", 102, 1) { InnerBase = new InnerBase() { innerId = 1002, innerName = "innername2" } });
            ChangeList(changeBaseTestList, 101);

            Console.WriteLine("changeBaseTestList" + JsonConvert.SerializeObject(changeBaseTestList));

            Console.WriteLine("staticInnerBaseTestList" + JsonConvert.SerializeObject(staticInnerBaseTestList));

        }

        public void ChangeList(List<BaseTest> changeBaseTestList, int id)
        {
            var lastBaseTest = changeBaseTestList.FirstOrDefault(p => p.id == id);
            Console.WriteLine(JsonConvert.SerializeObject(lastBaseTest));

            var selectList = staticInnerBaseTestList.Where(p => !changeBaseTestList.Select(q => q.InnerBase.innerId).Contains(p.innerId)).ToList();

            var baseTest = selectList.ToArray()[Random.Next(selectList.Count())];
            //lastBaseTest = JsonConvert.DeserializeObject<BaseTest>(JsonConvert.SerializeObject(baseTest));
            lastBaseTest.InnerBase = JsonConvert.DeserializeObject<InnerBase>(JsonConvert.SerializeObject(baseTest));
            lastBaseTest.InnerBase.innerId += 1000000;
            Console.WriteLine(JsonConvert.SerializeObject(lastBaseTest));

            lastBaseTest.groupid = 99999;
            Console.WriteLine(JsonConvert.SerializeObject(lastBaseTest));


        }

        public void TestRedisSortedSet()
        {
            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                redisManager[RedisDBName.Master].LockAction("wincountranking", () =>
                {
                    var skv = redisManager[RedisDBName.Master].CacheRedis.SortedSetRangeByScoreWithScores("WinCountRanking1", double.NegativeInfinity, double.PositiveInfinity, Exclude.None, Order.Descending, 0, 20);
                    for (int i = 0; i < skv.Length; i++)
                    {
                        Console.WriteLine($"{skv[i].Element},{skv[i].Score}");
                    }

                });
            });
        }

        public static void ResetWeekPointRanking()
        {
            int type = 2;
            string wckey = RDB_Master.TotalPointsRanking + type;
            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                redisManager[RedisDBName.Master].LockAction("totalpointsranking" + type, () =>
                {
                    try
                    {
                        redisManager[RedisDBName.Master].CacheRedis.SortedSetRemoveRangeByRank(wckey, 0, -1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"SaveWinCountRanking{ex}");
                        FileHandle.SaveLog($"SaveWinCountRanking{ex.Message},{ex.StackTrace}");
                    }

                });
            });
        }

        public static void TestRedisExistKey()
        {
            int itemCount = 0;
            string openid = ""; string name = ""; int role = 0;
            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                if (redisManager[RedisDBName.Account].CacheRedis.HashExists(RDB_Account.User, 1000000080))
                    openid = redisManager[RedisDBName.Account].CacheRedis.HashGet(RDB_Account.User, 1000000080);
                short viplevel = (short)redisManager[RedisDBName.Master].CacheRedis.HashGet($"ShareUserInfo:{10000000}:ShareUser", "viplevel");

                openid = redisManager[RedisDBName.Account].HashGet(RDB_Account.User, 10000) ?? "";
                name = redisManager[RedisDBName.Account].HashGet(RDB_Account.Nickname, openid) ?? "";


                if (redisManager[RedisDBName.Master].HashExists($"ShareUserInfo:1000000080:ShareUser", "role"))
                    role = redisManager[RedisDBName.Master].HashGet<int>($"ShareUserInfo:1000000080:ShareUser", "role");
            });
            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                if (redisManager[RedisDBName.Master].CacheRedis.KeyExists($"UserInfo:{1000000080}:UserItem"))
                {
                    // itemCount = redisManager[RedisDBName.Master].HashGet<GItemData>($"UserInfo:{1000000080}:UserItem", 80001).num;

                }
            });

            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                redisManager[RedisDBName.Room].HashDelete(RDB_Room.RoomInfo, 1212121212);

            });
            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                long heatTicks = (long)redisManager[RedisDBName.LoadBalancing].CacheRedis.HashGet($"RoomServer:1", "HeatTime");
            });
            Console.WriteLine(itemCount);
        }


        public static int CanInviteUser(long uid, long targetid, ref int serverId, out string name)
        {
            int errorCode = 1100;
            int svMasterId = 0;
            int svRoomId = 0;
            string userName = "";
            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                string openid = redisManager[RedisDBName.Account].HashGet(RDB_Account.User, uid) ?? "";
                userName = redisManager[RedisDBName.Account].HashGet(RDB_Account.Nickname, openid);
                /*
                if (redisManager[RedisDBName.Master].KeyExists("UserInServer"))
                {
                    if (redisManager[RedisDBName.Master].HashExists("UserInServer", targetid))
                    {
                        svId = redisManager[RedisDBName.Master].HashGet<int>("UserInServer", targetid);
                        errorCode = ErrorCode._0;
                    }
                }
                */

                svMasterId = GetServerId(redisManager, RedisDBName.Master, targetid);
                svRoomId = GetServerId(redisManager, RedisDBName.Room, targetid);

                if (svMasterId > 0 && svRoomId == 0)
                {
                    errorCode = 0;
                }
            });
            name = userName;
            serverId = svMasterId;
            return errorCode;
        }
        public static int GetServerId(RedisManager redisManager, string dbName, long uid)
        {
            int serverid = 0;
            if (redisManager[dbName].CacheRedis.KeyExists($"User:{uid}:InServer"))
            {
                serverid = (int)redisManager[dbName].CacheRedis.StringGet($"User:{uid}:InServer");
            }

            return serverid;
        }

    }




}
