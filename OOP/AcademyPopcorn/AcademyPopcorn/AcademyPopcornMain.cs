using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            InitializeBlocks(startCol, endCol, startRow, engine);

            InitializeSpecialBlocks(engine);

            InitializeWalls(engine);

            InitializeBall(engine);

            InitializeRacket(engine);
        }
  
        private static void InitializeRacket(Engine engine)
        {
            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }
  
        private static void InitializeBall(Engine engine)
        {
            // Problem 7. Test the MeteoriteBall by replacing the normal ball in the AcademyPopcornMain.cs file.
            Ball theBall = new UnstopableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);
        }
  
        private static void InitializeWalls(Engine engine)
        {
            // Problem 9. Test the UnpassableBlock and the UnstoppableBall by adding them to the engine in AcademyPopcornMain.cs file
            // Problem 1. The AcademyPopcorn class contains an IndestructibleBlock class. Use it to create side and ceiling walls to the game. 
            // You can ONLY edit the AcademyPopcornMain.cs file.
            for (int i = 0; i < WorldRows; i++)
            {
                Block currentIndestructibleBlock = new UnpassableBlock(new MatrixCoords(i, 0),false);
                engine.AddObject(currentIndestructibleBlock);
                currentIndestructibleBlock = new UnpassableBlock(new MatrixCoords(i, WorldCols - 1), false);
                engine.AddObject(currentIndestructibleBlock);
            }

            for (int i = 0; i < WorldCols; i++)
            {
                Block currentIndestructibleBlock = new UnpassableBlock(new MatrixCoords(0, i),true);
                engine.AddObject(currentIndestructibleBlock);
            }
        }
  
        private static void InitializeSpecialBlocks(Engine engine)
        {
            // Exploding block test
            Block explodingRock = new ExplodingBlock(new MatrixCoords(8, 17));
            engine.AddObject(explodingRock);

            Block BlockToExplode = new Block(new MatrixCoords(8, 18));
            engine.AddObject(BlockToExplode);
            BlockToExplode = new Block(new MatrixCoords(7, 18));
            engine.AddObject(BlockToExplode);
            BlockToExplode = new Block(new MatrixCoords(9, 18));
            engine.AddObject(BlockToExplode);

            // Gift Block test
            Block giftBlock = new GiftBlock(new MatrixCoords(16, WorldCols - 6));
            engine.AddObject(giftBlock);
        }
  
        private static void InitializeBlocks(int startCol, int endCol, int startRow, Engine engine)
        {
            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            EngineWithPlayerShooter gameEngine = new EngineWithPlayerShooter(renderer, keyboard, 200);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
