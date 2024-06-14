using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.CommandMode
{
    public class Command
    {
        private static Command _instance = new Command();

        private Command()
        {
            AddEvent();
        }

        public static Command GetInstance() { return _instance; }

        MsgListener msgListener = new MsgListener();
        private void AddEvent()
        {

            msgListener.AddEventListener(1, () => { Test1(); });

            msgListener.AddEventListener(1, () => { Console.WriteLine($"{System.DateTime.Now}test 11 start");Thread.Sleep(3); Console.WriteLine($"{System.DateTime.Now}test 11 end"); });
            msgListener.AddEventListener(2, () => { Console.WriteLine("test2"); });
            msgListener.AddEventListener(2, () => { Console.WriteLine("test22"); });
        }

        private void Test1()
        {

            Console.WriteLine($"{System.DateTime.Now}test1start");
            for (int i = 0; i < 100000000; i++)
            {
                Console.Write("");
            }
            Console.WriteLine($"{System.DateTime.Now}test1end");
        }

        public void Test()
        {
            while (true)
            {
                string msgCode = Console.ReadLine();
                msgListener.EventInvoke(Convert.ToInt32(msgCode));
                msgListener.EventInvoke1(Convert.ToInt32(msgCode));
            }
        }
    }

    public class MsgListener
    {

        Dictionary<int, List<Action>> ActionDic;
        Dictionary<int, Action> Action1Dic;
        public MsgListener()
        {
            ActionDic = new Dictionary<int, List<Action>>();
            Action1Dic = new Dictionary<int, Action>();
        }
        public void AddEventListener(int msgCode, Action action)
        {
            if (!ActionDic.ContainsKey(msgCode))
            {
                ActionDic.Add(msgCode, new List<Action>());
            }
            ActionDic[msgCode].Add(action);


            if (!Action1Dic.ContainsKey(msgCode))
            {
                Action1Dic.Add(msgCode, null);
            }
            Action1Dic[msgCode] += action;
        }



        public void EventInvoke(int msgCode)
        {
            if (ActionDic.ContainsKey(msgCode))
            {
                Console.WriteLine($"触发了ActionDic msgCode{msgCode}");
                foreach (Action action in ActionDic[msgCode])
                {
                    action.Invoke();
                }

            }
            else
            {
                Console.WriteLine($"没有{msgCode}");
            }
        }

        public void EventInvoke1(int msgCode)
        {
            if (Action1Dic.ContainsKey(msgCode))
            {
                Console.WriteLine($"触发了Action1Dic msgCode{msgCode}");
                Action1Dic[msgCode].Invoke();
            }
        }

    }
}
