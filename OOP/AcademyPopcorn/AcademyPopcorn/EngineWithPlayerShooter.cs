using System;
using System.Reflection;
using System.Linq;

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
            if (obj is ShootingRacket)
            {
                var currentRacket = GetCurrentRacket();
                base.AddObject(new ShootingRacket(currentRacket.TopLeft, currentRacket.Width));
            }
            else
            {
                base.AddObject(obj);
            }
        }
  
        // A little bit Reflection to get the the current value of the private field playerRacket. Since it's defined as private in the parrent it's not normaly accessible in the derived class.
        // It's used here to create the shooting racket at the same position as the existing racket.
        private Racket GetCurrentRacket()
        {
            var assembly = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == "Engine");
            var racketField = assembly.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField).FirstOrDefault(field => field.Name == "playerRacket");
            var currentRacket = racketField.GetValue(this) as Racket;
            return currentRacket;
        }

        public virtual void ShootPlayerRacket()
        {
            var currentRacket = GetCurrentRacket(); ;
            if (currentRacket is ShootingRacket)
            {
                (currentRacket as ShootingRacket).IsShooting = true;
            }
            
        }
    }
}
