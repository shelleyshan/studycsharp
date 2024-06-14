using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class RedisHelper
    {
        private static readonly ConfigurationOptions configurationOptions = ConfigurationOptions.Parse("192.168.10.12:6381,password=0");
        private static readonly object Locker =new object();
        private static ConnectionMultiplexer _redisConn;

        public static ConnectionMultiplexer RedisConn
        {
            get {
                if (_redisConn == null)
                { 
                lock(Locker)
                    {
                        if (_redisConn == null || !_redisConn.IsConnected)
                        {
                            _redisConn = ConnectionMultiplexer.Connect(configurationOptions);
                        }
                    }
                }
                return _redisConn;
            }
        }

        public static IDatabase GetDatabase()
        { 
        return RedisConn.GetDatabase(10);
        }

        public static void test()
        {
            string value = "abcdefg";
            GetDatabase().StringSet("mykey", value);
        }
    }
}
