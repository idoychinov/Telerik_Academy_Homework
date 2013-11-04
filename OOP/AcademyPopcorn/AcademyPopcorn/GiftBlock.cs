using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    // Problem 12. Implement a GiftBlock class. It should be a block, which "drops" a Gift object when it is destroyed. 
    // You must NOT edit any existing .cs file. Test the Gift and GiftBlock classes by adding them through the AcademyPopcornMain.cs file.

    class GiftBlock : Block
    {

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'G' } };
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> gift = new List<GameObject>();
            if (IsDestroyed)
            {
                gift = new List<GameObject> { new Gift(this.topLeft) };
            }
            return gift;
        }
    }
}
