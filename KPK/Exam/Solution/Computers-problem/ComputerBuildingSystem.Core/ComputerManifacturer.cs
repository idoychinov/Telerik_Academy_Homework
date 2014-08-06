namespace ComputerBuildingSystem.Core
{
    using ComputerBuildingSystem.Core.Interfaces;

    public abstract class ComputerManifacturer
    {
        protected IRandomProvider randomProvider = RandomProvider.GetInstance();

        public abstract PC ManifacturePC();

        public abstract Server ManifactureServer();

        public abstract Laptop ManifactureLaptop();
    }
}
