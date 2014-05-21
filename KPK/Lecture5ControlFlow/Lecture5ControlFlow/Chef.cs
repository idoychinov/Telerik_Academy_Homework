using System;

namespace Lecture5ControlFlow
{

    public class Chef
    {
        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private void Cut(Vegetable vegetable)
        {
            //...
        }

        private void Peel(Vegetable vegetable)
        {
            //...
        }

        public void Cook()
        {
            Bowl bowl;
            bowl = GetBowl();

            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();

            Peel(potato);
            Peel(carrot);

            Cut(potato);
            Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }
    }

    public class Vegetable
    {
        public bool HasBeenPeeled { get; set; }

        public bool IsNotRotten { get; set; }

        //...
    }

    public class Carrot : Vegetable
    {
        //...
    }

    public class Potato : Vegetable
    {
        //...
    }

    public class Bowl
    {
        public void Add(Vegetable vegetable)
        {
            //..
        }
    }
}
