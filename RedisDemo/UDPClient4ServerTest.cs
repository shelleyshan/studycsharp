using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class UDPClient4ServerTest
    {
        public static void Test()
        {
            try
            {
                UdpClient udpClient = new UdpClient(12000);
                string returnData = "client_end";
                do {
                    Console.WriteLine("服务器接收数据：………………");
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    returnData = Encoding.UTF8.GetString(receiveBytes);
                    Console.WriteLine("This is the message server received:" + returnData.ToString());

                    Thread.Sleep(1000);

                    Console.WriteLine("向客户端发送数据：………………");
                    udpClient.Connect(Dns.GetHostName().ToString(), 11000);

                    string sendStr = "我来自服务器端：" + DateTime.Now.ToString();
                    byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
                    udpClient.Send(sendBytes, sendBytes.Length);
                    Console.WriteLine("This is the message server send:" + sendStr);
                } while (returnData != "client_end");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
