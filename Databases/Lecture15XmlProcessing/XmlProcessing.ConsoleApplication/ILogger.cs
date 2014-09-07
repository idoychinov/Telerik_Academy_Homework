namespace XmlProcessing.ConsoleApplication
{
    public interface ILogger
    {
        void Message(string message);

        void MenuMessage(string message);

        void ErrorMessage(string message);

        void ProcessingMessage(string message);

        void SuccessMessage(string message);

    }
}
