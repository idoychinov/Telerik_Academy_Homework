namespace ComputerBuildingSystem.Core
{
    using System;
    using ComputerBuildingSystem.Core.Interfaces;
    public abstract class VideoCard : IVideoCard
    {
        private readonly ConsoleColor textColor;

        internal VideoCard(ConsoleColor textColor)
        {
            this.textColor = textColor;
        }

        public void DrawText(string text)
        {
            Console.ForegroundColor = this.textColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
