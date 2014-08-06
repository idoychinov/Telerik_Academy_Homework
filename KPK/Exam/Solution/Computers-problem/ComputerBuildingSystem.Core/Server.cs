﻿namespace ComputerBuildingSystem.Core
{
    using System;
    using ComputerBuildingSystem.Core.Interfaces;

    public class Server : Computer
    {
        public Server(ICpu cpu, IMotherboard motherboard)
            : base(cpu, motherboard)
        {
        }

        public override void Interact(int parameter)
        {
            this.Process(parameter);
        }

        private void Process(int parameter)
        {
            this.motherboard.SaveRamValue(parameter);
            string message;
            try
            {
               var number = this.cpu.SquareNumber(this.motherboard.LoadRamValue());
               message = number.ToString();
            }
            catch (ArgumentOutOfRangeException e)
            {
                message = e.Message;
            }
            this.motherboard.DrawOnVideoCard(message);
        }
    }
}
