namespace ComputerBuildingSystem.Core
{
    using ComputerBuildingSystem.Core.Interfaces;

    public abstract class ComputerManifacturer
    {
        private IRandomProvider randomProvider;

        public ComputerManifacturer()
        {
            this.randomProvider = RandomProvider.GetInstance();
        }

        protected IRandomProvider RandomGenerator
        {
            get
            {
                return this.randomProvider;
            }
        }

        public abstract PC ManifacturePC();

        public abstract Server ManifactureServer();

        public abstract Laptop ManifactureLaptop();
    }
}
