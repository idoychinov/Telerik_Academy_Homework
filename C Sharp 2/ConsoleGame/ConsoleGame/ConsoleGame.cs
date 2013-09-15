using System;
using System.Collections.Generic;
using System.Threading;
using System.Media;

class ConsoleGame
{
    public static ConsoleKeyInfo KeyInfo { get; set; }
    static byte choice;
    static byte cursorPosition = choice;

    static void Settings()
    {
        Console.Title = "Just Ninja";
        Console.WindowHeight = 25;
        Console.WindowWidth = 80;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        Console.ForegroundColor = ConsoleColor.White;
        Console.CursorVisible = false;
        DrawScreen.Start();

        //Console.SetCursorPosition(50, Console.WindowHeight - 3);
        //Console.WriteLine("Press any key to continue.");
        //KeyInfo = Console.ReadKey(true);
        Console.Clear();
    }

    static void Main()
    {
        Settings();
        //DrawScreen.DrawHeader("abc", ConsoleColor.Red);

        while (true)
        {
            MainMenu();

            if (choice == 1)
            {
                GameEngine();
            }
            else if (choice == 2)
            {
                HighScores();
            }
            else if (choice == 3)
            {
                HowToPlay();
            }
            else if (choice == 4)
            {
                Options();
            }
            else if (choice == 5)
            {
                Credits();
            }
            else if (choice == 6)
            {
                if (Exit())
                {
                    return;
                }
            }
        }
    }

    private static ConsoleKeyInfo MainMenu() // Draws the Main menu screen and provides functionality for moving the cursor between options.
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        DrawScreen.Start();

        choice = 1;
        cursorPosition = choice;

        choice = DrawScreen.StartinScreenInteraction(keyInfo, cursorPosition);
        keyInfo = Console.ReadKey(true);

        while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Spacebar)
        {
            cursorPosition = choice;
            choice = DrawScreen.StartinScreenInteraction(keyInfo, cursorPosition);
            keyInfo = Console.ReadKey(true);
        }

        return keyInfo;
    }

    static bool GameEngine()        //NEW GAME - main game logic
    {
        Console.Clear();
        DrawScreen.StoryScreen();
        Console.Clear();

        while (true)  // outher while - used for new game initialisation. Used after game restart, for new iteration of all ingame settings.
        {
            int gameControl = 1;
            int playerScore = 0;
            bool playerShoot = false;
            Random random = null;
            int enemyShoot = 0;
            int playerProjeDelay = 5;
            SoundPlayer music = new SoundPlayer(@"..\..\Sound\music.wav");

            using (music)
            {
                music.PlayLooping();
            }

            GameStatus currentStatus = new GameStatus();
            GameElement player = new GameElement(ElementType.Player);
            List<GameElement> enemies = new List<GameElement>();
            List<GameElement> playerProj = new List<GameElement>();
            List<GameElement> enemyProj = new List<GameElement>();

            while (true)
            {
                currentStatus.Score = playerScore;
                DrawScreen.DrawGame(player, playerProj, enemies, enemyProj, currentStatus);
                //make wrapper method all updates (make step, projectile and enemy position update and colision check
                player.MakeStep();

                // make new method for projectile update
                List<int> toRemove = new List<int>();

                for (int i = 0; i < playerProj.Count; i++)
                {
                    if (playerProj[i].UpdateProjectile())
                    {
                        toRemove.Add(i);
                    }
                }

                foreach (int item in toRemove)
                {
                    playerProj.RemoveAt(item);
                }

                toRemove.Clear();

                for (int i = 0; i < enemyProj.Count; i++)
                {
                    if (enemyProj[i].UpdateProjectile())
                    {
                        toRemove.Add(i);
                        enemyShoot--;
                    }
                }

                foreach (int item in toRemove)
                {
                    enemyProj.RemoveAt(item);
                }

                if (enemies.Count == 0)
                {
                    currentStatus.SpawnedEnemies++;
                    Random rnd = new Random();
                    ElementType enemyType = ElementType.EnemySnake;

                    switch (rnd.Next(1, 6))
                    {
                        case 1: enemyType = ElementType.EnemySnake; break;
                        case 2: enemyType = ElementType.EnemyNinja; break;
                        case 3: enemyType = ElementType.EnemyDog; break;
                        case 4: enemyType = ElementType.EnemyBat; break;
                        case 5: enemyType = ElementType.EnemyShooter; break;
                    }

                    enemies.Add(new GameElement(enemyType));
                }

                foreach (GameElement enemy in enemies)
                {
                    enemy.MakeStep(currentStatus.SpawnRate);
                }

                int currentEnemy = 0;

                while (currentEnemy < enemies.Count)
                {
                    if (enemies[currentEnemy].Coordinate <= 0)
                    {
                        enemies.RemoveAt(currentEnemy);
                    }
                    else
                    {
                        currentEnemy++;
                    }
                }

                // IF there is time implement real cooldown for actions jump, crouch, fire to prevent spamming
                if (Console.KeyAvailable)
                {
                    KeyInfo = Console.ReadKey(true);

                    if (KeyInfo.Key == ConsoleKey.Escape)
                    {
                        gameControl = PauseMenu();

                        if (gameControl < 0)
                        {
                            music.Stop();
                            return true;
                        }
                        else if (gameControl == 0)
                        {
                            break;
                        }
                        else if (gameControl > 0)
                        {
                            continue;
                        }

                        return true;
                    }
                    else if (KeyInfo.Key == ConsoleKey.Spacebar)
                    {
                        GameElement projectile = new GameElement(ElementType.PlayerProjectile);
                        projectile.ElementState = player.ElementState;
                        playerProj.Add(projectile);
                        playerShoot = true;
                        playerProjeDelay = 9;
                    }
                    else if (!player.StateCooldown())
                    {
                        if (KeyInfo.Key == ConsoleKey.UpArrow)
                        {
                            player.Jump();
                        }
                        else if (KeyInfo.Key == ConsoleKey.DownArrow)
                        {
                            player.Crouch();
                        }
                    }
                }
                // Random enemy enemy shooter shoot - not very often

                if (enemies.Count > 0 && enemies[0].Type == ElementType.EnemyShooter && enemyShoot == 0)
                {
                    GameElement projectile = new GameElement(ElementType.EnemyProjectile);

                    foreach (GameElement enemy in enemies)
                    {
                        projectile.ElementState = enemy.ElementState;
                    }

                    enemyProj.Add(projectile);
                    enemyShoot++;
                }
                //when player shoot enemy is tring to keep itself
                if (playerShoot)
                {
                    playerProjeDelay--;

                    if (playerProjeDelay == 0)
                    {
                        foreach (GameElement enemy in enemies)
                        {
                            if (enemy.Type == ElementType.EnemyShooter)
                            {
                                switch (random.Next(1, 3))
                                {
                                    case 1: enemy.Jump(); break;
                                    case 2: enemy.Crouch(); break;
                                    case 3: enemy.Walk(); break;
                                }
                            }
                        }
                    }

                    playerShoot = false;
                }

                //Destroy enemy
                toRemove.Clear();

                if (enemies.Count > 0 && playerProj.Count > 0)
                {
                    for (int i = 0; i < playerProj.Count; i++)
                    {
                        if (playerProj[i].Coordinate + 5 <= Console.WindowWidth &&
                            (playerProj[i].Coordinate == enemies[0].Coordinate ||
                             playerProj[i].Coordinate + 1 == enemies[0].Coordinate ||
                             playerProj[i].Coordinate + 2 == enemies[0].Coordinate ||
                             playerProj[i].Coordinate + 3 == enemies[0].Coordinate ||
                             playerProj[i].Coordinate + 4 == enemies[0].Coordinate) &&
                                playerProj[i].ElementState == enemies[0].ElementState)
                        {
                            if (enemies[0].Type == ElementType.EnemyNinja)
                            {
                                currentStatus.Score = 5;
                            }
                            else if (enemies[0].Type == ElementType.EnemyShooter)
                            {
                                currentStatus.Score = 20;
                            }
                            else
                            {
                                currentStatus.Score = 10;
                            }
                            //SoundPlayer hitSound = new SoundPlayer(@"..\..\Sound\Hit.wav");
                            //hitSound.Play();
                            //Console.Beep();
                            if (currentStatus.SpawnedEnemies == currentStatus.LevelEnemies)
                            {
                                Thread.Sleep(150);
                                DrawScreen.LevelClear();    //If all enemies in current level are dead
                                Console.Clear();
                                currentStatus.NextLevel();  //Start New Level
                            }

                            enemies.RemoveAt(0);
                            playerProj.RemoveAt(i);
                            break;
                        }
                    }
                }
                if (enemyProj.Count > 0)
                {
                    for (int i = 0; i < enemyProj.Count; i++)
                    {
                        if (enemyProj[i].Coordinate - 5 > 0 &&
                            (enemyProj[i].Coordinate == player.Coordinate ||
                            enemyProj[i].Coordinate - 1 == player.Coordinate ||
                            enemyProj[i].Coordinate - 2 == player.Coordinate ||
                            enemyProj[i].Coordinate - 3 == player.Coordinate ||
                            enemyProj[i].Coordinate - 4 == player.Coordinate ||
                             enemyProj[i].Coordinate - 5 == player.Coordinate) &&
                            enemyProj[i].ElementState == player.ElementState)
                        {
                            if (currentStatus.LifeLoss())
                            {
                                DrawScreen.GameOverScreen();
                                DrawScreen.GameOverScreenInteraction(currentStatus);
                                music.Stop();
                                return true;    //Go to the main menu
                            }
                        }
                    }
                }
                else if (enemies.Count > 0 &&
                         (player.Coordinate == enemies[0].Coordinate ||
                          player.Coordinate - 1 == enemies[0].Coordinate ||
                          player.Coordinate - 2 == enemies[0].Coordinate ||
                          player.Coordinate - 3 == enemies[0].Coordinate ||
                          player.Coordinate - 4 == enemies[0].Coordinate ||
                          player.Coordinate - 5 == enemies[0].Coordinate))
                {
                    if (((enemies[0].Type == ElementType.EnemySnake && player.ElementState != Altitude.High) ||
                         (enemies[0].Type == ElementType.EnemyDog && player.ElementState != Altitude.High) ||
                         (enemies[0].Type == ElementType.EnemyBat && player.ElementState != Altitude.Low) ||
                          enemies[0].Type == ElementType.EnemyNinja) && currentStatus.LifeLoss())
                    {
                        DrawScreen.GameOverScreen();
                        DrawScreen.GameOverScreenInteraction(currentStatus);
                        return true;    //Go to the main menu
                    }

                    enemies.RemoveAt(0);
                }

                Thread.Sleep(150);
            }
        }
    }

    static int PauseMenu()
    {
        Console.Clear();
        DrawScreen.Pause();
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        choice = 1;
        cursorPosition = choice;

        while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Spacebar && keyInfo.Key != ConsoleKey.Escape)
        {
            choice = DrawScreen.PauseInteraction(keyInfo, cursorPosition);
            cursorPosition = choice;
            keyInfo = Console.ReadKey(true);
        }

        if (keyInfo.Key == ConsoleKey.Escape)
        {
            return 1;       //CONTINUE
        }

        if (choice == 1)    //CONTINUE
        {
            Console.Clear();
            return 1;
        }
        else if (choice == 2)   //NEW GAME
        {
            return 0;
        }
        else if (choice == 3)   //HOW TO PLAY
        {
            DrawScreen.HowToPlayScreen();
            keyInfo = Console.ReadKey(true);
            keyInfo = DrawScreen.SingleOptionScreenInteraction(keyInfo);

            return PauseMenu();
        }
        else if (choice == 4)   //MAIN MENU
        {
            Console.Clear();
            cursorPosition = 1;
            string question = "Are you sure you want to exit to the main menu?";
            keyInfo = new ConsoleKeyInfo();
            SystemSounds.Exclamation.Play();
            choice = DrawScreen.YesNoInteraction(question, keyInfo, cursorPosition);

            while (keyInfo.Key != ConsoleKey.Escape && keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Spacebar)
            {
                keyInfo = Console.ReadKey(true);
                cursorPosition = choice;
                choice = DrawScreen.YesNoInteraction(question, keyInfo, cursorPosition);
            }

            if (keyInfo.Key == ConsoleKey.Escape || choice == 1)
            {
                return PauseMenu();     //"NO"
            }
            else
            {
                return -1;              //"YES"
            }
        }

        return PauseMenu();
    }

    public static void HighScores()
    {
        DrawScreen.HighScoreScreen();
        KeyInfo = Console.ReadKey(true);
        KeyInfo = DrawScreen.SingleOptionScreenInteraction(KeyInfo);
    }

    private static void HowToPlay()
    {
        DrawScreen.HowToPlayScreen();
        KeyInfo = Console.ReadKey(true);
        KeyInfo = DrawScreen.SingleOptionScreenInteraction(KeyInfo);
    }

    private static void Options()
    {
        DrawScreen.SettingsScreen();
        cursorPosition = 1;
        cursorPosition = DrawScreen.SettingsScreenInteraction(KeyInfo, cursorPosition);
        KeyInfo = Console.ReadKey(true);

        while (KeyInfo.Key != ConsoleKey.Escape && KeyInfo.Key != ConsoleKey.Enter && KeyInfo.Key != ConsoleKey.Spacebar)
        {
            cursorPosition = DrawScreen.SettingsScreenInteraction(KeyInfo, cursorPosition);
            KeyInfo = Console.ReadKey(true);
        }
    }

    private static void Credits()
    {
        DrawScreen.CreditsScreen();
        KeyInfo = Console.ReadKey(true);
        KeyInfo = DrawScreen.SingleOptionScreenInteraction(KeyInfo);
    }

    private static bool Exit()
    {
        Console.Clear();
        cursorPosition = 1;
        string question = "Are you sure you want to quit the game?";
        SystemSounds.Exclamation.Play();
        KeyInfo = new ConsoleKeyInfo();
        choice = DrawScreen.YesNoInteraction(question, KeyInfo, cursorPosition = 1);

        while (KeyInfo.Key != ConsoleKey.Escape && KeyInfo.Key != ConsoleKey.Enter && KeyInfo.Key != ConsoleKey.Spacebar)
        {
            KeyInfo = Console.ReadKey(true);
            cursorPosition = choice;
            choice = DrawScreen.YesNoInteraction(question, KeyInfo, cursorPosition);
        }

        if (KeyInfo.Key != ConsoleKey.Escape && choice != 1)
        {
            Console.Clear();
            string thanks = "Thank you for playing!";
            Console.SetCursorPosition((Console.WindowWidth - thanks.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(thanks);
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            return true;
        }
        else
        {
            return false;
        }
    }
}