using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(int age, string name)
            : base(age, name, AnimalSex.Male)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MrrRRRSSSrrrSSs");
        }
    }
}
