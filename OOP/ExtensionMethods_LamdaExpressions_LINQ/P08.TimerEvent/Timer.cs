using System;
using System.Linq;
using System.Threading;

namespace P08.TimerEvent
{
    class Timer
    {
        private const int interval = 1000;
        private const string defaultOutputFormat = "Time: {0:HH:mm:ss}";  // diferent formats for the timer can be used by changing this or adding more formats and a way for chosing between them
        private Thread timerThread;
        public EventHandler<TimerEventArgs> RaiseEvent;

        public Timer()
        {
            this.timerThread = new Thread( () => 
            {
                while(true)
                {
                    RaiseEvent(this, new TimerEventArgs(DateTime.Now));
                    Thread.Sleep(interval);
                } 
            });
        }

        public string FormatOutput()
        {
            return defaultOutputFormat;
        }

        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }

        public void Start()
        {
            timerThread.Start();
        }

        public void Stop()
        {
            timerThread.Abort();
        }

        // Provides timer format
        public override string ToString()
        {
            return defaultOutputFormat;
        }
    }
}
