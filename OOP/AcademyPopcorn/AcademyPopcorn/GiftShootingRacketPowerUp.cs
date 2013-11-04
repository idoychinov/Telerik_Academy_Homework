using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class GiftShootingRacketPowerUp : GameObject
    {
        public GiftShootingRacketPowerUp(MatrixCoords giftCoordinates)
            : base(giftCoordinates, new char[,] { { ' ' } })
        {
            this.IsDestroyed = true;
        }

        public override void Update()
        {
        }
    }
}
