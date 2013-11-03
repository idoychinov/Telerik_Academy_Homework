using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    // Problem 6. Implement a MeteoriteBall. It should inherit the Ball class and should leave a trail of TrailObject objects. 
    // Each trail objects should last for 3 "turns". Other than that, the Meteorite ball should behave the same way as the normal ball. 
    // You must NOT edit any existing .cs file.

    public class MeteoriteBall : Ball
    {
        private const char TRAIL_SYMBOL = '@';
        private const int TRAIL_LIFETIME = 3;

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedTrail = new List<GameObject>();
            producedTrail.Add(new TrailObject(this.topLeft,TRAIL_SYMBOL,TRAIL_LIFETIME));
            return producedTrail;
        }
    }
}
