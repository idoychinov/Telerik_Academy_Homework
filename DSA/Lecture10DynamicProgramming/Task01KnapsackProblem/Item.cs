namespace Task01KnapsackProblem
{
    using System;

    class Item
    {
        public Item(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Value = cost;
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }

        public override string ToString()
        {
            return this.Name + " Weight: " + this.Weight + " Cost: " + this.Value;
        }
    }
}
