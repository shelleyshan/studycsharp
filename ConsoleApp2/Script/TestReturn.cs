using Newtonsoft.Json;
using Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp2.Script
{
    public class TestReturn : BaseCacheHandler<bool>
    {
        public static TestReturn Instance = new TestReturn();

        static TestReturn()
        {
            Instance = new TestReturn();
        }

        public List<string> TestList;

        TestReturn() : base()
        {

        }
        public void Test()
        {
            while (true)
            {
                string key = Console.ReadLine();

                if (string.IsNullOrEmpty(key))
                {
                    continue;
                }
                var keys = key.Split(':');
                switch (keys[0])
                {
                    case "fuzhi":
                        TestList = GetCacheAllKeys();
                        break;
                    case "output":
                        Console.WriteLine(JsonConvert.SerializeObject(TestList));
                        break;
                    case "delete":
                        RemoveByKey(keys[1]);
                        break;
                    case "add":
                        AddOrUpdateCache(keys[1], true);
                        break;
                    default: break;
                }
            }
        }

        public override void InitData()
        {
            // throw new NotImplementedException();
        }
    }
}
