namespace Helpers.Contracts
{
    public interface ILogger
    {
        void Message(string message);

        void MenuMessage(string message);

        void ErrorMessage(string message);

        void ProcessingMessage(string message);

        void Progress(int total, int current);

        void SuccessMessage(string message);

    }
}
