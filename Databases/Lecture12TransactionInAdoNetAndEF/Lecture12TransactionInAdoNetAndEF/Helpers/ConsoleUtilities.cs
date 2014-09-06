namespace Lecture12TransactionInAdoNetAndEF
{
    using System;

    public static class ConsoleUtilities
    {
        const ConsoleColor ConsoleMenuColor = ConsoleColor.Cyan;
        const ConsoleColor ConsoleErrorColor = ConsoleColor.Red;
        const ConsoleColor ConsoleSuccessColor = ConsoleColor.Green;
        const ConsoleColor ConsoleProcessingColor = ConsoleColor.DarkYellow;
        const ConsoleColor ConsoleDefaultColor = ConsoleColor.White;

        private static void ConsoleMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleDefaultColor;
        }

        public static void MenuMessage(string message)
        {
            var formatMenuMessage = "#################################\nMenu:\n" + message + "\n#################################";
            ConsoleMessage(formatMenuMessage, ConsoleMenuColor);
        }

        public static void ErrorMessage(string message)
        {
            ConsoleMessage("### Error: " + message + " ###",ConsoleErrorColor);
        }

        public static void SuccessMessage(string message)
        {
            ConsoleMessage("### Success: " + message + " ###", ConsoleSuccessColor);
        }

        public static void ProcessingMessage(string message)
        {
            ConsoleMessage("### Processing: " + message + " ###", ConsoleProcessingColor);
        }

    }
}
