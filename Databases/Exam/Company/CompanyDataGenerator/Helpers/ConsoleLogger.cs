namespace Helpers
{
    using System;

    using Contracts;

    public class ConsoleLogger : ILogger
    {
        const ConsoleColor ConsoleMenuColor = ConsoleColor.Cyan;
        const ConsoleColor ConsoleErrorColor = ConsoleColor.Red;
        const ConsoleColor ConsoleSuccessColor = ConsoleColor.Green;
        const ConsoleColor ConsoleProcessingColor = ConsoleColor.DarkYellow;
        const ConsoleColor ConsoleDefaultColor = ConsoleColor.White;

        private void ConsoleMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleDefaultColor;
        }

        public void Message(string message)
        {
            ConsoleMessage(message, ConsoleDefaultColor);
        }

        public void MenuMessage(string message)
        {
            var formatMenuMessage = "##################################################################" +
                "\nMenu:\n" + message + "\n##################################################################";
            ConsoleMessage(formatMenuMessage, ConsoleMenuColor);
        }

        public void ErrorMessage(string message)
        {
            ConsoleMessage("### Error: " + message + " ###", ConsoleErrorColor);
        }

        public void SuccessMessage(string message)
        {
            ConsoleMessage("### Success: " + message + " ###", ConsoleSuccessColor);
        }

        public void ProcessingMessage(string message)
        {
            ConsoleMessage("### Processing: " + message + " ###", ConsoleProcessingColor);
        }

        public void Progress(int total, int current)
        {
            var percentDone = ((double)current / total) * 100;
            Console.CursorLeft = 0;
            Console.ForegroundColor = ConsoleProcessingColor;
            Console.Write("Progress: {0: 0.00}%",percentDone);
            Console.ForegroundColor = ConsoleDefaultColor;
        }
    }
}
