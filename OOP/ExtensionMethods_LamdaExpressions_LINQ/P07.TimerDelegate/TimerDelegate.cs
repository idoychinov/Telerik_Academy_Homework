using System;
using System.Threading;

// Problem 7. Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace P07.TimerDelegate
{
    public delegate void ExecutedFunction(int param);
    public class TimerDelegate
    {
        static Thread timerThread;
        static void FunctionToExecute(int interval)
        {
            Console.WriteLine("I'm a function that is executed every {0} seconds! Timestamp: {1: HH:mm:ss}", interval,DateTime.Now);
        }

        static void StartTimer(int interval, ExecutedFunction function)
        {
            Console.WriteLine("Press any key to stop the timer\n");

            timerThread = new Thread(() =>
            {
                while (true)
                {
                    function(interval);
                    Thread.Sleep(interval * 1000);
                }
            });
            timerThread.Start();
        }

        public static void StopTimer()
        {
            timerThread.Abort();
        }

        static void Main()
        {
            int interval = 2;
            ExecutedFunction function = new ExecutedFunction(FunctionToExecute);
            StartTimer(interval, function);
            while (!Console.KeyAvailable)
            {
                // main program flow
            }
            StopTimer();
        }
    }
}
