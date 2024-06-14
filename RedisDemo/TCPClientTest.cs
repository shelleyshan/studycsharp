using SocketDemo.SocketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class TCPClientTest
    {
        private static int portNum = 11000;
        private static string hostName = Dns.GetHostName();
        public static async Task Test()
        {
            try
            {
                TcpClient client = new TcpClient();
                IPEndPoint ipEP = new IPEndPoint(IPAddress.Parse("192.168.10.16"), 11000);
                await client.ConnectAsync(ipEP);

                Console.WriteLine("连接成功");

                NetworkStream ns = client.GetStream();
                while (true)
                {
                    byte[] buffer = new byte[1024];

                    int bytesRead = ns.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        var model = TestProtoBufTools.Deserialize<CommunicationMessage>(buffer, bytesRead);

                        await Console.Out.WriteLineAsync("client send:" + model.id + model.Content);
                    }

                }

                // client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
