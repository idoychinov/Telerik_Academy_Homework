namespace ComputerBuildingSystem.Core
{
    using System;
    public class MonochromeVideoCard : VideoCard
    {
        private const ConsoleColor TextColor = ConsoleColor.Gray;
        public MonochromeVideoCard()
            : base(TextColor)
        {
        }
    }
}
