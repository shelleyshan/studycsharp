using DBModel.Model;
using LoadBalancingClientFrame;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WemakeDataCacheFrame;

namespace Script
{
    public static class SaveDataToRedis
    {
        public static object obj = new object();
      
    }

    public static class Test
    {
        public static void testFunc()
        {
            Type tsu = typeof(CommonFunction);
            MethodInfo minfo = tsu.GetMethod("GreaterThanOrEqualTo");
            bool rst = (bool)minfo.Invoke(null, new object[] { 12, 13 });

            Console.WriteLine(rst);
        }

        public static void GetRoleList()
        {
            var roleDic = new Dictionary<string, UserRole>();
            RedisManagerFactory.UsingRedisManager(redisManager =>
            {
                roleDic = redisManager[RedisDBName.Master].HashGetAllDictionary<string, UserRole>($"UserInfo:1000002023:UserRole");
            });

            Console.WriteLine(JsonConvert.SerializeObject(roleDic));
        }
    }

    public static class CommonFunction
    {
        public static bool GreaterThanOrEqualTo(int x, int y)
        {
            return x >= y;
        }

        public static bool GreaterThan(int x, int y)
        {
            return x > y;
        }

        public static bool EqualTo(int x, int y)
        {
            return x == y;
        }

        public static bool LessThanOrEqualTo(int x, int y)
        {
            return x <= y;
        }
        public static bool LessThan(int x, int y)
        {
            return x < y;
        }
    }
}
