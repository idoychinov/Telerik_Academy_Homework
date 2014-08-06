namespace ComputerBuildingSystem.Core
{
    using ComputerBuildingSystem.Core.Interfaces;

    public abstract class Computer : IComputer
    {        
        protected ICpu cpu;

        protected IMotherboard motherboard;

        public Computer(ICpu cpu, IMotherboard motherboard)
        {
            this.motherboard = motherboard;
            this.cpu = cpu;
        }

        public virtual void Interact(int parameter)
        {

        }
    }
}
