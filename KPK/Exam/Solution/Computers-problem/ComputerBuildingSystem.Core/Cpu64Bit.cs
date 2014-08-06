namespace ComputerBuildingSystem.Core
{
    using System;
    using ComputerBuildingSystem.Core.Interfaces;

    public class Cpu64Bit : Cpu
    {
        private const byte NumberOfBits = 32;
        private const int MinimumSqrInputNumber = 0;
        private const int MaxiumumSqrInputNumber = 1000;

        public Cpu64Bit(byte numberOfCores, IRandomProvider randomProvider)
            : base(numberOfCores, NumberOfBits, MinimumSqrInputNumber, MaxiumumSqrInputNumber, randomProvider)
        {
        }
    }
}
