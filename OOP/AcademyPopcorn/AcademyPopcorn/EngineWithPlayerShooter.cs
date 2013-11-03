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

        public void ShootPlayerRacket()
        {
        }
    }
}
