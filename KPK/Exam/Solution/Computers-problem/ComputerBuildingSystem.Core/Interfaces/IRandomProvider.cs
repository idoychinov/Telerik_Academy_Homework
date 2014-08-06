namespace ComputerBuildingSystem.Core.Interfaces
{
    public interface IRandomProvider
    {
        int GetRandomNumberInRange(int minNumber, int maxNumber);
    }
}
