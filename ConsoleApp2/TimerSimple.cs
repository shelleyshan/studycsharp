/// <summary>
/// 测试定时器
/// </summary>
internal class TimerSimple
{
    public static Action TimerAction;
    public static void Start()
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Enabled = true;
        timer.Interval = 1000; //每5秒执行一次
        timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        timer.Start();
    }

    static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Console.WriteLine($"{System.DateTime.Now.ToString()}--开始执行{nameof(timer_Elapsed)} ThreadID: {Thread.CurrentThread.ManagedThreadId.ToString()}");
   
            TimerAction?.BeginInvoke(null, null);

      
        Console.WriteLine($"{System.DateTime.Now.ToString()}-结束执行{nameof(timer_Elapsed)} ThreadID: {Thread.CurrentThread.ManagedThreadId.ToString()}");
    }
}