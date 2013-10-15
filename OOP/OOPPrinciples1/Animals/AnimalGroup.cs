using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class AnimalGroup
    {
        public string GroupName { get; set; }
        public double AverageAge { get; set; }

        public AnimalGroup(string name, double age)
        {
            this.GroupName = name;
            this.AverageAge = age;
        }
    }
}
