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
            this.Motherboard.SaveRamValue(this.Cpu.GenerateRandomNumber(1, 10));
            if (this.Motherboard.LoadRamValue() != parameter)
            {
                this.Motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", this.Motherboard.LoadRamValue()));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}
