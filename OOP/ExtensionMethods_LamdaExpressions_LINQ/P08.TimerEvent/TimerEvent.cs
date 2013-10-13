using System;

// Problem 8. * Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above using .NET events and following the best practices.

namespace P08.TimerEvent
{
    class TimerEvent
    {
        // Method that will be subscribed to event and will be executed each time this event is raised
        static public void DisplayTime(object sender, TimerEventArgs e)
        {
            int cursorX = Console.CursorLeft;
            int cursorY = Console.CursorTop;
            Console.SetCursorPosition(1, 1);
            Console.WriteLine(sender.ToString(),e.TimerTime);
            Console.SetCursorPosition(cursorX, cursorY);
        }

        static void Main()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("To exit the program use Alt+E shortcut!");
            Console.SetCursorPosition(0, 5);

            Timer timer = new Timer();
            timer.RaiseEvent += DisplayTime;
            timer.Start();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.E && key.Modifiers == ConsoleModifiers.Alt)
                    {
                        Console.WriteLine();
                        break;
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                    }
                }
            }
            timer.Stop();
        }
    }

 
}
