using System;

public class GameStatus
{
    const int MaxLives = 5;  // maximum number of lives for the player
    const int InitialEnemies = 5;  // initial enemies on level 1
    const int EnemyCountIncrease = 2; // used in the calculation of how much enemies shoud be spawnd when starting new level
    const int EnemySpawnIncrease = 1; // used in calculation of how fast shoud the enemies be when starting new level
    const int LevelCap = 10; // defines the level at witch the spawn rate and spawn number of enemies should reach maximum. In subsequent levles those parameters wount be increased, to prevent the game from becoming unplayable.
    private int level;          // current level
    private int score;          // current score
    private int levelEnemies;   // number of enemies for the current level. Affter all those enemies are spawned and there are no more enemies on the screen the level ends.
    private int spawnedEnemies; // current number of spawned enemies
    private int lives;          // current pleyer lives
    private int spawnRate;      // rate at which the enemies are spawned

    public int Score  //property providing access to "score" private member
    {
        get { return score; }
        set { score = score + value; }
    }

    public int Level //property providing access to "level" private member
    {
        get { return level; }
    }

    public int Lives  //property providing access to "lives" private member
    {
        get { return lives; }
    }

    public int LevelEnemies  //property providing access to "levelEnemies" private member
    {
        get { return levelEnemies; }
    }

    public int SpawnedEnemies   //property providing access to "spawnedEnemies" private member
    {
        get { return spawnedEnemies; }
        set { spawnedEnemies = value; }
    }

    public int SpawnRate  //property providing access to "spawnRate" private member
    {
        get { return spawnRate; }
    }

    public GameStatus()  // constructor for the class, initializing the instance for level one.
    {
        level = 1;
        score = 0;
        levelEnemies = InitialEnemies;
        spawnedEnemies = 0;
        lives = MaxLives;
        spawnRate = 1;
    }

    public void NextLevel()  //method used to set the level setings for the instance 
    {
        level++;
        spawnedEnemies = 0;

        if (level <= LevelCap) // no enemy count or spawn rate increase above the level cap
        {
            if (level % 2 != 0)  // on oddlevels max enemy number increases on even levels spawn rate increases
            {
                levelEnemies = levelEnemies + (EnemyCountIncrease * level);
            }
            else
            {
                spawnRate = spawnRate + EnemySpawnIncrease;
            }
        }
    }

    public void LevelEnemy()  // used to increase the spawnedEnemies counter 
    {
        if (spawnedEnemies == levelEnemies)
        {
            return;
        }
        else
        {
            spawnedEnemies++;
        }
    }

    public bool LifeLoss()  // used to decrease the player lives and indicate if the lives reached 0
    {
        lives--;

        if (lives == 0)
        {
            return true; // indicate that the game is over
        }

        return false;
    }
}

