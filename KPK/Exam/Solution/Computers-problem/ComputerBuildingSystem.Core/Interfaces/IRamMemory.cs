namespace ComputerBuildingSystem.Core.Interfaces
{
    public interface IRamMemory
    {
        int Amount { get; }

        int CurrentValue { get; set; }

    }
}
