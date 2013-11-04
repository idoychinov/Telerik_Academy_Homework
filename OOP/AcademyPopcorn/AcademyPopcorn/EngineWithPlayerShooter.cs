using System;

namespace AcademyPopcorn
{

    // Problem 4. Inherit the Engine class. Create a method ShootPlayerRacket. Leave it empty for now.
    public class EngineWithPlayerShooter : Engine
    {
        
        public EngineWithPlayerShooter(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public EngineWithPlayerShooter(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : base(renderer, userInterface, sleepTime)
        {
        }

        public override void AddObject(GameObject obj)
        {
            if (obj is GiftShootingRacketPowerUp)
            {
                this.AddObject(new ShootingRacket(this.playerRacket.TopLeft,this.playerRacket.Width));
            }
            else
            {
                base.AddObject(obj);
            }
        }

        public virtual void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).IsShooting=true;
            }
            
        }
    }
}
