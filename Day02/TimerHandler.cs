using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timer = System.Timers.Timer;

namespace Day02
{
    public class TimerHandler
    {
        private Timer _timer;
        private double _interval;
        private Action handler;

        public TimerHandler(double interval, Action handler)
        {
            this._interval = interval;
            this.handler = handler;
        }
        public void Start()
        {
            Stop();
            _timer = new Timer();
            _timer.Interval = _interval;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;

        }

        private void _timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            handler?.Invoke();
        }

        public void Stop()
        {
            if (_timer != null)
            {
                _timer.Enabled = false;
                _timer.Stop();
                _timer.Close();
                _timer.Dispose();
                _timer = null;

            }
        }
    }

    public class TimerTest
    {
        private TimerHandler timer1;
        private TimerHandler timer2;
        private TimerHandler timer3;

        public TimerTest()
        {
            timer1 = new TimerHandler(2000, () => { Console.WriteLine($"{System.DateTime.Now},this is timer1, occurs at 2 second"); });
            timer2 = new TimerHandler(3000, () => { Console.WriteLine($"{System.DateTime.Now},this is timer2, occurs at 3 seconds"); });
            timer3 = new TimerHandler(5000, () => { Console.WriteLine($"{System.DateTime.Now},this is timer3, occurs at 5 seconds"); });
        }

        public void Start()
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        public void Change()
        {
            timer1.Stop();
            timer1 = new TimerHandler(4000, () => { Console.WriteLine($"{System.DateTime.Now},this is timer1, change from at 4 second to four seconds"); });
            timer1.Start();
        }

    }
}
