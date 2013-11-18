using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // 10. Implement an ExplodingBlock. It should destroy all blocks around it when it is destroyed. You must NOT edit any existing .cs file. 
    //Hint: what does an explosion "produce"?

    class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { '*' } };
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedBlastWave = new List<GameObject>();
            if (this.IsDestroyed)
            {
                for (int row = -1; row < 2; row++)
                {
                    for (int col = -1; col < 2; col++)
                    {
                        producedBlastWave.Add(new BlastWave(new MatrixCoords(this.topLeft.Row + row, this.topLeft.Col + col)));
                    }
                }

                return producedBlastWave;
            }
            else
            {
                return producedBlastWave;
            }
        }
    }
}
