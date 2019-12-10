using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class TimerManager
    {
        List<DelayTimer> toRemove = new List<DelayTimer>();
        List<DelayTimer> timers = new List<DelayTimer>();

        private static TimerManager instance = new TimerManager();
        private bool isPaused = false;
        public static TimerManager Instance
        {
            get
            {
                return instance;
            }
        }

        private TimerManager()
        {
        }

        public List<DelayTimer> ToRemove { get => toRemove; }
        public List<DelayTimer> Timers { get => timers; }

        public static void Add(DelayTimer Timer) { Instance.Timers.Add(Timer); }
        public static void Remove(DelayTimer Timer) { Instance.ToRemove.Add(Timer); }

        public void Update(GameTime gametime)
        {
            if (!isPaused)
            {
                foreach (DelayTimer timer in ToRemove.ToList()) Timers.Remove(timer);
                ToRemove.Clear();
                foreach (DelayTimer timer in Timers.ToList()) timer.Update((float)gametime.ElapsedGameTime.Milliseconds);
            }

        }

        public void DestroyNamedTimer(string tag)
        {
            foreach (var Timer in Timers)
            {
                string Tag = tag.ToUpperInvariant();
                if (Timer.Type.ToUpperInvariant().Equals(Tag))
                {
                    Timer.Destroy();
                }
            }
        }

        public void Pause()
        {
            if (!isPaused)
            {
                this.isPaused = true;
            }

            else
            {
                this.isPaused = false;
            }
        }


    }
}
