using System;

namespace AcademyPopcorn
{
    // Problem 8. Implement an UnstoppableBall and an UnpassableBlock. The UnstopableBall only bounces off UnpassableBlocks and will destroy
    // any other block it passes through. The UnpassableBlock should be indestructible. Hint: Take a look at the RespondToCollision method, 
    // the GetCollisionGroupString method and the CollisionData class.

    class UnpassableBlock : IndestructibleBlock
    {
        public const char TopSymbol = '_';
        public new const string CollisionGroupString = "unpassableBlock";

        public UnpassableBlock(MatrixCoords upperLeft,bool isOnTop)
            : base(upperLeft)
        {
            if (isOnTop)
            {
                this.body[0, 0] = UnpassableBlock.TopSymbol;
            }
            else
            {
                this.body[0, 0] = UnpassableBlock.Symbol;
            }
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "unstopableBall";
        }
    }
}
