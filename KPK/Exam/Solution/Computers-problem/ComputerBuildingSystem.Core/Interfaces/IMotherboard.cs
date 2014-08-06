namespace ComputerBuildingSystem.Core.Interfaces
{
    public interface IMotherboard
    {
        /// <summary>
        /// Gets the currently saved number in the Ram memory of the computer;
        /// </summary>
        /// <returns>Value currently in the RAM</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves the passed parameter as the current number in the Ram memory of the computer;
        /// </summary>
        /// <param name="value">Value to be saved in the RAM</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws the passed text data to the Video card of the computer
        /// </summary>
        /// <param name="data">Text that will be passed to the Video Card for visualization</param>
        void DrawOnVideoCard(string data);

    }
}
