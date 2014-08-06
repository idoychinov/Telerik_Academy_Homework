namespace ComputerBuildingSystem.Core.Interfaces
{
    public interface IBattery
    {
        void Charge(int chargeAmount);

        int CurrentPower();
    }
}
