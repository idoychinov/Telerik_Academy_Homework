namespace ComputerBuildingSystem.Core
{
    using System;

    public class ColorfulVideoCard : VideoCard
    {
        private const ConsoleColor TextColor = ConsoleColor.Green;

        public ColorfulVideoCard()
            : base(TextColor)
        {
        }
    }
}
