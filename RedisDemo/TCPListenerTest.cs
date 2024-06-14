using SocketDemo.SocketModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class TCPListenerTest
    {
        private int portNum = 11000;

        static TCPListenerTest _instance;

        public static TCPListenerTest Instance
        {
            get
            {

                if (_instance == null)
                {
                    _instance = new TCPListenerTest();
                }
                return _instance;
            }
        }

        public void Test()
        {
            bool done = false;

            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, portNum));
            listener.Start();//开启监听
            while (!done)
            {
                Console.WriteLine("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();//检测来自客户端的连接请求
                IPEndPoint clientIP = client.Client.RemoteEndPoint as IPEndPoint;
                Console.WriteLine(clientIP.Address + ":" + clientIP.Port);

                bool isNew = false;
                if (!TcpClientCache.ContainsKey(clientIP.Address + ":" + clientIP.Port) || !TcpClientCache[clientIP.Address + ":" + clientIP.Port].Connected)
                {
                    Console.WriteLine("new Connection accepted");
                    TcpClientCache.TryAdd(clientIP.Address + ":" + clientIP.Port, client);
                    isNew = true;
                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(TcpClientCache.Keys));
                }

                if (isNew)
                {

                    Task.Run(() =>
                    {
                        IPEndPoint clientIP = client.Client.RemoteEndPoint as IPEndPoint;
                        NetworkStream ns = client.GetStream();//建立和连接的客户端的数据流
                        while (true)
                        {
                            byte[] byteTime = TestProtoBufTools.Serialize(TestProtoBufTools.Test());
                            try
                            {
                                ns.Write(byteTime, 0, byteTime.Length);
                                Thread.Sleep(3000);

                            }
                            catch (Exception ex)
                            {
                                //Console.WriteLine(ex.ToString());
                                ns.Dispose();


                                lock (clientIP.Address + ":" + clientIP.Port)
                                {
                                    client.Close();
                                    client.Dispose();

                                    TcpClientCache.Remove(clientIP.Address + ":" + clientIP.Port, out TcpClient client1);
                                }

                            }

                        }

                    });

                }
            }
            listener.Stop();
        }


        public static ConcurrentDictionary<string, TcpClient> TcpClientCache = new ConcurrentDictionary<string, TcpClient>();




    }
}
