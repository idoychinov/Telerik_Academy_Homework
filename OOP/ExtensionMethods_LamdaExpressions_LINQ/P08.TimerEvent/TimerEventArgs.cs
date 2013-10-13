using System;

namespace P08.TimerEvent
{
    public class TimerEventArgs : EventArgs
    {
        private DateTime timerTime;

        public TimerEventArgs(DateTime time)
        {
            this.timerTime = time;
        }

        public DateTime TimerTime
        {
            get
            {
                return timerTime;
            }
        }

    }
}
