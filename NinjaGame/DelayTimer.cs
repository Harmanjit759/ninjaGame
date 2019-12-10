using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class DelayTimer
    {

        private Action Trigger { get; set; }
        public float Interval { get; set; }

        public string Type { get; set; }

        float Elapsed;

        private DelayTimer()
        {
        }

        public void Update(float milliseconds)
        {
            Elapsed += milliseconds;
            if (Elapsed >= Interval)
            {
                Trigger.Invoke();
                Destroy();
            }
        }

        public void Destroy()
        {
            TimerManager.Remove(this);
        }

        public static DelayTimer Create(float Interval, Action Trigger, string timerType = "")
        {
            DelayTimer Timer = new DelayTimer() { Interval = Interval, Trigger = Trigger, Type = timerType };
            TimerManager.Add(Timer);
            return Timer;
        }

    }
}
