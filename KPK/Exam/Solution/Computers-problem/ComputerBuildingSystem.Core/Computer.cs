namespace ComputerBuildingSystem.Core
{
    using ComputerBuildingSystem.Core.Interfaces;

    public abstract class Computer : IComputer
    {
        private ICpu cpu;

        private IMotherboard motherboard;

        public Computer(ICpu cpu, IMotherboard motherboard)
        {
            this.Motherboard = motherboard;
            this.Cpu = cpu;
        }

        protected ICpu Cpu
        {
            get
            {
                return this.cpu;
            }

            private set
            {
                this.cpu = value;
            }
        }

        protected IMotherboard Motherboard
        {
            get
            {
                return this.motherboard;
            }

            private set
            {
                this.motherboard = value;
            }
        }

        public virtual void Interact(int parameter)
        {
        }
    }
}
