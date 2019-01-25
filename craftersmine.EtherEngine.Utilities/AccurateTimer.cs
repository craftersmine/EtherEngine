using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Utilities
{
    /// <summary>
    /// Represents an accurate timer. This class cannot be inherited
    /// </summary>
    public sealed class AccurateTimer
    {
        private delegate void TimerEventDel(int id, int msg, IntPtr user, int dw1, int dw2);
        private const int TIME_PERIODIC = 1;
        private const int EVENT_TYPE = TIME_PERIODIC;// + 0x100;  // TIME_KILL_SYNCHRONOUS causes a hang ?!
        [DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [DllImport("winmm.dll")]
        private static extern int timeEndPeriod(int msec);
        [DllImport("winmm.dll")]
        private static extern int timeSetEvent(int delay, int resolution, TimerEventDel handler, IntPtr user, int eventType);
        [DllImport("winmm.dll")]
        private static extern int timeKillEvent(int id);

        Action mAction;
        private int mTimerId;
        private TimerEventDel mHandler;  // NOTE: declare at class scope so garbage collector doesn't release it!!!

        /// <summary>
        /// Gets current delay between ticks
        /// </summary>
        public int Delay { get; private set; }

        /// <summary>
        /// Creates a new instance of AccurateTimer with specified delay and callback
        /// </summary>
        /// <param name="callback">Tick callback</param>
        /// <param name="delay">Delay between ticks</param>
        public AccurateTimer(Action callback, int delay)
        {
            mAction = callback;
            Delay = delay;
        }

        /// <summary>
        /// Starts timer
        /// </summary>
        public void Start()
        {
            timeBeginPeriod(1);
            mHandler = new TimerEventDel(TimerCallback);
            mTimerId = timeSetEvent(Delay, 0, mHandler, IntPtr.Zero, EVENT_TYPE);
        }

        /// <summary>
        /// Stops timer
        /// </summary>
        public void Stop()
        {
            int err = timeKillEvent(mTimerId);
            timeEndPeriod(1);
            System.Threading.Thread.Sleep(100);// Ensure callbacks are drained
        }

        private void TimerCallback(int id, int msg, IntPtr user, int dw1, int dw2)
        {
            if (mTimerId != 0)
                mAction();
        }
    }
}
