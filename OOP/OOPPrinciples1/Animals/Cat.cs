using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Cat :Animal
    {
        public Cat(int age, string name, AnimalSex sex)
            : base(age, name, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Miauuuuuu, RrrrSssss");
        }
    }
}
