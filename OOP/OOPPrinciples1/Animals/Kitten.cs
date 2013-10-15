using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(int age, string name)
            : base(age, name, AnimalSex.Female)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Miau,miau");
        }
    }
}
