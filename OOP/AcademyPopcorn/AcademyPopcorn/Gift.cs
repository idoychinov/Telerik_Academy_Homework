using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{

    // Problem 11. Implement a Gift class. It should be a moving object, which always falls down. 
    // The gift shouldn't collide with any ball, but should collide (and be destroyed) with the racket. You must NOT edit any existing .cs file.

    class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";

        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '%' } }, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> shootingRacket = new List<GameObject>();
            if (IsDestroyed)
            {
                shootingRacket = new List<GameObject> { new ShootingRacket(this.topLeft,1) };
            }
            return shootingRacket;
        }
    }
}
