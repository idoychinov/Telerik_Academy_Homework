namespace ComputerBuildingSystem.Core
{
    using System;
    using ComputerBuildingSystem.Core.Interfaces;

    public abstract class Cpu : ICpu
    {
        private readonly byte numberOfCores;

        private readonly byte numberOfBits;

        private readonly int minimumSqrInputNumber;

        private readonly int maxiumumSqrInputNumber;

        private readonly IRandomProvider randomProvider;

        public Cpu(byte numberOfCores, byte numberOfBits, int minimumSqrInputNumber, int maxiumumSqrInputNumber, IRandomProvider randomProvider)
        {
            this.numberOfCores = numberOfCores;
            this.numberOfBits = numberOfBits;
            this.minimumSqrInputNumber = minimumSqrInputNumber;
            this.maxiumumSqrInputNumber = maxiumumSqrInputNumber;
            this.randomProvider = randomProvider;
        }

        public int GenerateRandomNumber(int minimumNumber, int maximumNumber)
        {
            int randomNumber;
            randomNumber = this.randomProvider.GetRandomNumberInRange(this.minimumSqrInputNumber, maximumNumber);
            return randomNumber;
        }

        public int SquareNumber(int number)
        {
            if (number < this.minimumSqrInputNumber)
            {
                throw new ArgumentOutOfRangeException("Number too low.", new ArgumentOutOfRangeException());
            }
            else if (number > this.maxiumumSqrInputNumber)
            {
                throw new ArgumentOutOfRangeException("Number too high.", new ArgumentOutOfRangeException());
            }
            else
            {
                int numberSquared = number * number;
                return numberSquared;
            }
        }

    }

}
