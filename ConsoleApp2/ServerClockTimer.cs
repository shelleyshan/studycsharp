using System;
using System.Timers;
namespace WemakeServer.Script
{

    public class ServerClockTimer
    {
        public static ServerClockTimer Instance;

        public Action FiveSecondAction;//每5秒钟执行一次
        public Action OneMinuteAction;//每分钟执行一次
        public Action FiveMinuteAction;//每5分钟执行一次
        public Action TenMinuteAction;//每10分钟执行一次
        public Action ThirtyMinuteAction;//每30分钟执行一次
        public Action HourAction; //每小时整点执行一次
        public Action DayAction;//每日处理事件
        public Action WeekAction;//每周处理事件

        public List<Action> DoActions;
    
        static ServerClockTimer()
        {
            Instance = new ServerClockTimer();
        }

        private System.Timers.Timer timer;  //计时器

        public ServerClockTimer()
        {
            DoActions = new List<Action>();
        }
        public void Start()
        {
            //Console.WriteLine($"当前线程{Thread.CurrentThread.ManagedThreadId}");
            Stop();
            timer = new System.Timers.Timer();
            timer.Interval = 1000;  //设置计时器事件间隔执行时间
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }
        public void Stop()
        {
            if (timer != null)
            {
                timer.Enabled = false;
            }
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int intWeek = (int)e.SignalTime.DayOfWeek;
            int intHour = e.SignalTime.Hour;
            int intMinute = e.SignalTime.Minute;
            int intSecond = e.SignalTime.Second;

            //每5秒钟执行一次
            if (e.SignalTime.Second % 5 == 0)
            {
                DoActions.Add(FiveSecondAction);
            }

            //每分钟执行一次
            if (e.SignalTime.Second == 0)
            {
                DoActions.Add(OneMinuteAction);
            }
            //每5分钟执行一次
            if (e.SignalTime.Minute % 5 == 0 && e.SignalTime.Second == 0)
            {
                DoActions.Add(FiveMinuteAction);
            }
            //每10分钟执行一次
            if (e.SignalTime.Minute % 10 == 0 && e.SignalTime.Second == 0)
            {
                DoActions.Add(TenMinuteAction);
            }
            //每30分钟执行一次
            if (e.SignalTime.Minute % 30 == 0 && e.SignalTime.Second == 0)
            {
                DoActions.Add(ThirtyMinuteAction);
            }
            //每小时整点执行一次
            if (e.SignalTime.Minute == 0 && e.SignalTime.Second == 0)
            {
                DoActions.Add(HourAction);
            }
            //每天 00：00：00开始执行程序  
            if (e.SignalTime.Hour == 0 && e.SignalTime.Minute == 0 && e.SignalTime.Second == 0)
            {
                Console.WriteLine($"每天00:00:00！开始执行一次{e.SignalTime.ToLongTimeString()}");
                DoActions.Add(DayAction);
            }
            //每周一 00：00：00开始执行程序
            if (e.SignalTime.DayOfWeek == DayOfWeek.Monday && e.SignalTime.Hour == 0 && e.SignalTime.Minute == 0 && e.SignalTime.Second == 0)
            {
                Console.WriteLine($"每周一 00:00:00！开始执行一次{e.SignalTime.ToLongDateString() + e.SignalTime.ToLongTimeString()}");
                DoActions.Add(WeekAction);
            }
            if (DoActions.Count > 0)
            {
                for (int i = 0; i < DoActions.Count; i++)
                {
                    DoActions[i]?.Invoke();
                }
                DoActions.Clear();
            }
            
        }
    }
}

