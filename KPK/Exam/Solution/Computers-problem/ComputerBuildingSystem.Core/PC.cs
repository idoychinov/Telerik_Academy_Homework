namespace ComputerBuildingSystem.Core
{
    using ComputerBuildingSystem.Core.Interfaces;
    public class PC : Computer
    {
        public PC(ICpu cpu, IMotherboard motherboard)
            : base(cpu, motherboard)
        {
        }

        public override void Interact(int parameter)
        {
            this.PlayGame(parameter);
        }

        private void PlayGame(int parameter)
        {
            this.motherboard.SaveRamValue(this.cpu.GenerateRandomNumber(1, 10));
            if (this.motherboard.LoadRamValue() != parameter)
            {
                this.motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", this.motherboard.LoadRamValue()));
            }
            else
            {
                this.motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}
