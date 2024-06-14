using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class IPDemo
    {
        /// <summary>
        /// 获取主机名
        /// </summary>
        /// <returns></returns>
        public static void GetHostName()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry ipH = new IPHostEntry();
            ipH = Dns.Resolve(hostName);
            Console.WriteLine(hostName);


        }

        public static void GetHost()
        {
            Console.WriteLine("please input hostname or ip needed to be resolved");
            string str = Console.ReadLine();
            IPHostEntry hostInfo = Dns.Resolve(str);
            string strHost = hostInfo.HostName.ToString();
            Console.WriteLine($"host name is {strHost}");
        }

        public static void GetIPList()
        {
            Console.WriteLine("please input the hostname");
            string str = Console.ReadLine();
            IPHostEntry IPH = Dns.GetHostByName(str);
            IPAddress[] myIp = IPH.AddressList;
            foreach (IPAddress ips in myIp)
            {
                Console.WriteLine(ips.ToString());
            }

        }

        public static void GetIPAddress()
        {
            IPAddress ip = IPAddress.Parse("192.169.10.16");
            Console.WriteLine($"any:{IPAddress.Any},broadcast is {IPAddress.Broadcast}, IPv6Any is {IPAddress.IPv6Any}, IPv6Loopback is {IPAddress.IPv6Loopback}, IPv6None is {IPAddress.IPv6None}, Loopback is {IPAddress.Loopback}, None is {IPAddress.None}"); 

        }

        public static void Test()
        {
            while (true)
            {
                string str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        GetHostName();
                        break;
                    case "2":
                        GetHost();
                        break;
                    case "3":
                        GetIPList();
                        break;
                    case "4":
                        GetIPAddress();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
