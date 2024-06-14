using ConsoleApp2;
using ConsoleApp2.Script;
using LoadBalancingClientFrame;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Script;
using WemakeDataCacheFrame;
using WemakeMySqlFrame;
using WemakeRedisFrame;
using Script;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Asn1.Crmf;
using ProtoBuf;
using Org.BouncyCastle.Asn1.Cmp;
using System.Xml.Linq;
using System;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IO;
using FrameTest;
using WemakeServer.Script;
using ConsoleApp2.DesignMode.AbstractFactory;
using ConsoleApp2.DesignMode.DecoratorMode;
using ConsoleApp2.ObjectOriented;
using ConsoleApp2.DesignMode.CommandMode;
using ConsoleApp2.DesignMode.ResponsibilityMode;
using ConsoleApp2.DesignMode.FlyweightPattern;
using ConsoleApp2.WeiQiGame;
using ConsoleApp2.Attribute2;

Console.OutputEncoding = System.Text.Encoding.Unicode;//设置当前环境代码页为UTF8，解决中文乱码

//加载并初始化项目的数据
//--拉取配置信息
IConfigurationRoot configuration = SettingsConfig.CreateConfiguration("appsettings.json");
//--redis
SettingsConfig.gRedisSettings = SettingsConfig.CreateGroupSetting<RedisSettings>(configuration, "RedisSetting");
RedisManagerFactory.BinderSettingsConfig(SettingsConfig.gRedisSettings);

SettingsConfig.gMySqlInfos = SettingsConfig.CreateGroupSetting<GMySqlInfo>(configuration, "MysqlSetting");
MySqlManagerFactory.BinderSettingsConfig(SettingsConfig.gMySqlInfos);

string file = configuration.GetValue<string>("RedisDumpFile");

long timetick = System.DateTime.Now.AddDays(-1).Ticks;

long timercurrenttick = System.DateTime.Now.Ticks;

//Console.WriteLine(TimeSpan.FromTicks(timercurrenttick - timetick).TotalDays);


string str = "";
//var strobj = JsonConvert.DeserializeObject<BaseTest>(str);




//BaseTest bs = null; 

//Console.WriteLine(JsonConvert.SerializeObject(strobj));

//string bsstr = JsonConvert.SerializeObject(bs);

//Console.WriteLine($"bsstr {bsstr}");

//Console.WriteLine("bs"+JsonConvert.DeserializeObject<BaseTest>(bsstr));

//SaveDataToRedis.Start(file);

//Test.GetRoleList();

//TestEvent.Test5();
//TestEvent.Test6();
//TestEvent.Test12();
//Console.ReadLine();

//TestDerive.Test2();
//Test11.Test1();

//TestStaticInstance.Instance.InnerBaseTest();

//TestStaticInstance.ResetWeekPointRanking();

//PBaseTest.TestGroupBy();

//RestClient restClient = new("http://123.56.217.164:28005");
//s = restClient.Get("Login/Test");

//RestClient restClient = new("http://192.168.31.200:8009");
//s = restClient.Get("Login/Test");

//DateTime lastlogouttime = System.DateTime.Now.AddHours(-20);
//var s = (System.DateTime.Now- lastlogouttime).TotalSeconds;
//var ss = (System.DateTime.Now.Date- lastlogouttime.Date).TotalDays;
//Console.WriteLine(ss);

//TestGrammer.Main();
//Test0506.TestStruct();
//Console.ReadLine();


//TestRemove.Test();

//TestStaticInstance.TestRedisExistKey();
//int roomid = 1;

//TestStaticInstance.CanInviteUser(100000001, 100000002,ref roomid, out string name);
//Person p1 = new Person();
//Student student = new Student();
//Person p2 = new Student();
//Student s1 = p2 as Student;


//while (true)
//{
//    string input = Console.ReadLine();
//    switch (input)
//    {
//        case "connection":
//            RestClient restClient = new("http://192.168.31.200:8002");
//            var s = restClient.Get("Login/CheckConnection");
//            Console.WriteLine(s);
//            break;
//    }

//}
//Dictionary<int, int> countDic = new Dictionary<int, int>();

//for (int i = 0; i < 10000; i++)
//{
//    int j = WemakeRandom.Range(1, 7);

//    if (!countDic.ContainsKey(j))
//    {
//        countDic.Add(j, 0);
//    }
//    countDic[j]++;
//}
//Console.WriteLine(JsonConvert.SerializeObject(countDic));


//for (int i = 0; i < 10000; i++)
//{
//    Task.Run(() =>
//    {
//        RestClient restClient = new("http://192.168.31.81:8801");

//        var body = new { type = 0, deviceId = "c1", key = "1", value = "ekdkkdk" };
//        var s = restClient.Post(JsonConvert.SerializeObject(body), "Login/AccountLogin");
//    });

//    Console.ReadLine();
//}
//var mfdc = new System.Net.Http.MultipartFormDataContent();
//mfdc.Headers.Add("ContentType", "multipart/form-data");//声明头部
//mfdc.Add(new System.Net.Http.StringContent("type"), "0");//参数, 内容在前,参数名称在后
//mfdc.Add(new System.Net.Http.StringContent("deviceId"), "c1");
//mfdc.Add(new System.Net.Http.StringContent("key"), "用户1");
//mfdc.Add(new System.Net.Http.StringContent("value"), "123456");
//var clientTask = new System.Net.Http.HttpClient().PostAsync("http://192.168.31.81:8801/Login/AccountLogin", mfdc);//发起异步请求
//clientTask.Wait();//等待请求结果
//if (clientTask.Result.IsSuccessStatusCode)
//{
//    //请求正常
//    var resultTask = clientTask.Result.Content.ReadAsStringAsync();//异步读取返回内容
//    resultTask.Wait();//等读取返回内容
//    var resultStr = resultTask.Result;//返回内容字符串
//    Console.WriteLine(resultStr);
//}
//else
//{
//    Console.WriteLine("请求异常");
//    //请求异常
//}
//LazyTest.TestMain();

//string path = @"c:\temp\MyTest.txt";
//string path2 = @"c:\temp\\MyTest.txt";
//Console.WriteLine(Path.GetFullPath(path));
//Console.WriteLine(Path.GetFullPath(path2));
//All.Test();


//double swanLakePrice = 100.0;
//Console.WriteLine($"The cost of a ticket to the ballet is {swanLakePrice :C}");

//TestActionParam.Test();

//var test = TestReturn.Instance;

//test.Test();

//ServerClockTimer.Instance.Start();

//ServerClockTimer.Instance.OneMinuteAction = () =>
//{
//    Console.WriteLine($"{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}执行1分钟Action");

//    TestActionParam.TestAction();
//};
//Console.ReadLine();

//TimerSimple.TimerAction += () =>
//{
//    Console.WriteLine("当前开始执行第一个方法:" + DateTime.Now.ToString() + " ThreadID:" + Thread.CurrentThread.ManagedThreadId.ToString());
//    //当前任务需要执行2秒

//    Thread.Sleep(2000);
//    Console.WriteLine("当前结束开始执行第一个方法:" + DateTime.Now.ToString() + " ThreadID:" + Thread.CurrentThread.ManagedThreadId.ToString());
//};

//TimerSimple.TimerAction += () =>
//{
//    Console.WriteLine("当前开始执行第二个方法::" + DateTime.Now.ToString() + " ThreadID:" + Thread.CurrentThread.ManagedThreadId.ToString());
//    //当前任务需要执行2秒
//    Thread.Sleep(2000);
//    Console.WriteLine("当前结束开始执行第二个方法:" + DateTime.Now.ToString() + " ThreadID:" + Thread.CurrentThread.ManagedThreadId.ToString());
//};
//TimerSimple.Start();
//while (true)
//{
//    Tester.Instance.TestCalculate();
//}

//Test1.TestAbstractFactory();

//DecoratorPatternTest.Test();

//ImplementsTest.Test();
//TestGiveParamcs a = new TestGiveParamcs();
//a.Test();

//TestResponsibility.GetInstance().Test();
//TestResponsibility.GetInstance().Test();
//TestResponsibility.GetInstance().Test();

//TestFlyweight.GetInstance().Test();
//Game.GetInstance().StartGame();


//TestWork.GetInstance().Test();
TestClass.TestVirtual();
Console.ReadLine();