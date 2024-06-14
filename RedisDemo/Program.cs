namespace RedisDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input the number 1 is for server, 2 is for client");

            //RedisHelper.test();
            //TCPListenerTest.Test();



            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                    TCPListenerTest.Instance.Test();
                    break;
                case "2":
                    TCPClientTest.Test();
                    break;
                    case "3":
                    IPDemo.Test();
                    break;
                default: break;
            }




            Console.ReadLine();
        }
    }
}
