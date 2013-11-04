using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class BlastWave : Ball
    {
        public BlastWave(MatrixCoords topLeft)
            : base(topLeft, new MatrixCoords(0,0))
        {
            this.body = new char[,] { { 'X' } };
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }
    }
}
