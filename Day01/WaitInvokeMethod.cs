using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

public static class WaitInvokeMethod
{
    private static ConcurrentBag<BinderTimer> timerPool;

    static WaitInvokeMethod()
    {
        timerPool = new ConcurrentBag<BinderTimer>();
    }
    private static BinderTimer GiveTimer(int s)
    {
        BinderTimer result = null;
        if (timerPool.Count > 0)
        {
            if (timerPool.TryTake(out result))
            {
                Console.WriteLine($"计时器缓存获取{timerPool.Count}");
                result.Second = s;
                return result;
            }
        }
        if (result == null)
        {
            Console.WriteLine($"计时器创建获取{timerPool.Count}");
            result = new BinderTimer(s);
            result.EndHandle = SaveTimer;
            return result;
        }
        return null;
    }

    private static void SaveTimer(BinderTimer timer)
    {
        if (timer != null)
        {
            timerPool.Add(timer);
            Console.WriteLine($"计时器保存缓存{timerPool.Count}");
        }
    }

    public static BinderTimer UsingWaitInvoke(int s, Action handle)
    {
        BinderTimer result = GiveTimer(s);
        result.Start(handle);
        Console.WriteLine($"计时器启动{s}");
        return result;
    }
}
public class BinderTimer
{
    public Action Handle;
    public Action<BinderTimer> EndHandle;
    public Timer timer;

    public double Interval { get { return timer.Interval; } set { timer.Interval = value; } }
    public bool Enabled { get { return timer.Enabled; } set { timer.Enabled = value; } }
    public double Second { get { return timer.Interval / 1000; } set { timer.Interval = value * 1000; } }

    public BinderTimer(double s)
    {
        timer = new Timer(s * 1000);
        timer.Enabled = true;
        timer.Elapsed += Timer_Elapsed;
    }

    public void Close()
    {
        Handle = null;
        timer.Close();
        EndHandle?.Invoke(this);
    }

    public void Start(Action handle)
    {
        Handle = handle;
        timer.Start();
    }

    private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        try
        {
            Handle?.Invoke();
        }
        catch { }
        finally
        {
            timer.Close();
        }
        EndHandle?.Invoke(this);
    }
}
