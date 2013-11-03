using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    // Problem 5. Implement a TrailObject class. It should inherit the GameObject class and should have a constructor which takes an 
    //additional "lifetime" integer. The TrailObject should disappear after a "lifetime" amount of turns. You must NOT edit any
    //existing .cs file. Then test the TrailObject by adding an instance of it in the engine through the AcademyPopcornMain.cs file.

    public class TrailObject : GameObject
    {
        private int lifetime;

        public TrailObject(MatrixCoords topLeft, char body, int lifetime)
            : base(topLeft, new char[,]{{body}})
        {
            if (lifetime < 1)
            {
                throw new ArgumentOutOfRangeException("Lifetime must be 1 or more");
            }
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            this.lifetime--;
            if (this.lifetime < 1)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
