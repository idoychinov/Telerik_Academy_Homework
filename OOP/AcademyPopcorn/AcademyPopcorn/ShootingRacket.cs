using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    // Problem 13. Implement a shoot ability for the player racket. The ability should only be activated when a Gift object falls on the racket. 
    // The shot objects should be a new class (e.g. Bullet) and should destroy normal Block objects (and be destroyed on collision with any block). 
    // Use the engine and ShootPlayerRacket method you implemented in task 4, but don't add items in any of the engine lists through the ShootPlayerRacket
    // method. Also don't edit the Racket.cs file. Hint: you should have a ShootingRacket class and override its ProduceObjects method.

    class ShootingRacket : Racket
    {
        public bool IsShooting { get; set; }
        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.body = GetShootingRacketBody(width);
        }

        char[,] GetShootingRacketBody(int width)
        {
            char[,] body = new char[1, width];

            for (int i = 0; i < width; i++)
            {
                body[0, i] = '^';
            }

            return body;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsShooting)
            {
                this.IsShooting = false;
                return new List<GameObject> { new Bullet(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col + (this.Width / 2))) };
            }
            return new List<GameObject>();
        }
    }
}
