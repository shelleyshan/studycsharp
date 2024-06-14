using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class InteractiveTcpClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;

        private bool isRunning = true;
        private readonly object sendLock = new object();

        private string serverIP;
        private int port;

        public InteractiveTcpClient(string server, int port)
        {
            serverIP = server;
            port = port;
            tcpClient = new TcpClient(server, port);
            stream = tcpClient.GetStream();
            BeginReceive();
        }

        private void BeginReceive()
        {
            byte[] buffer = new byte[1024];
            try
            {
                stream.BeginRead(buffer, 0, buffer.Length, ReadCallback, buffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error receiving data:" + ex.Message);
                Reconnect();
            }
        }

        private void Reconnect()
        {
            isRunning = false;
            try
            {
                tcpClient.Close();
                tcpClient = new TcpClient();
                tcpClient.Connect(serverIP, port);
                stream = tcpClient.GetStream();
                isRunning = true;
                BeginReceive();
                Console.WriteLine("Reconnected to server");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reconnection failedL"+ex.Message);
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            if (!isRunning)
            {
                return;
            }
            try
            {
                int bytesRead = stream.EndRead(ar);
                if (bytesRead > 0)
                {
                    // 异步读取的数据存储在原始缓冲区中
                    byte[] buffer = ar.AsyncState as byte[];
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received:" + message);
                    BeginReceive();
                }
                else
                {
                    Console.WriteLine("Disconnected by server.");
                    Reconnect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error receiving data:" + ex.Message);
                Reconnect();
            }
        }

        public void SendData(string data)
        {
            if (!isRunning) return;
            lock (sendLock)
            {
                try
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(data);
                    stream.Write(buffer, 0, buffer.Length);
                    Console.WriteLine("Sent to server:" + data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending data:"+ex.Message);
                    Reconnect();
                }
            }
        }

        public void Stop()
        {
            isRunning = false;
            tcpClient.Close();
        }
    }
}
