using System;

namespace AcademyPopcorn
{
    // Problem 8. Implement an UnstoppableBall and an UnpassableBlock. The UnstopableBall only bounces off UnpassableBlocks and will destroy
    // any other block it passes through. The UnpassableBlock should be indestructible. Hint: Take a look at the RespondToCollision method, 
    // the GetCollisionGroupString method and the CollisionData class.

    class UnstopableBall : MeteoriteBall
    {
        public new const string CollisionGroupString = "unstopableBall";

        public UnstopableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override string GetCollisionGroupString()
        {
            return UnstopableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains("unpassableBlock")||
                 collisionData.hitObjectsCollisionGroupStrings.Contains("racket"))
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                {
                    this.Speed.Row *= -1;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                {
                    this.Speed.Col *= -1;
                }
            }
        }

    }
}
