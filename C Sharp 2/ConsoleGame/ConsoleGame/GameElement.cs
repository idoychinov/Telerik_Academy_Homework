using System;

public enum Altitude { Low = 1, Mid = 2, High = 3 };  // used to defined the states in witch an element can be
public enum ElementType { Player = 1, PlayerProjectile = 2, EnemySnake = 3, EnemyNinja = 4, EnemyDog = 5, EnemyBat = 6, EnemyShooter = 7, EnemyProjectile = 8 };  // used to define the posible element types

public class GameElement  // holds data for each game element (player, enemies and projectiles) and provied basic functionality for them, like initializing, returning or seting coordinates, changing states, ect.
{
    int x; //x coordinate of the element
    static ConsoleColor playerColor = ConsoleColor.White; // player color, currently static so it can be accessed prior to creaton of the player element in the settings menu. It can be implemented in the GameStatus class.
    static char projectileShape = '*'; // player projectile shape, currently static so it can be accessed prior to creaton of the player element in the settings menu. It can be implemented in the GameStatus class.
    const int JumpTime = 5;  // defines how long does a jump last after single keypress.
    const int CrouchTime = 5; // defines how long does a crouch last after single keypress.
    private Altitude alt;  // the elements altitude (y position). In the current context an element can have only 3 positions the y coordinate is calculated depending on them and the element type. 
    private readonly ElementType type; // type of element
    private int stateTime;  // counter that shows how much time the element (currently used only for player) has been in different than default state. Used for jump and crouch.
    private bool step; // used for drawing the element in two diferent states - for example /\ and |, in order to simulate walking/flying/ect effect.

    public GameElement(ElementType setType)  // constructor for GameElement that requires ElementType in order to initialize an object with the apropriate 
    {
        switch (setType)
        {
            case ElementType.Player: x = 8; type = ElementType.Player; alt = Altitude.Mid; break;
            case ElementType.PlayerProjectile: x = 11; type = ElementType.PlayerProjectile; break;
            case ElementType.EnemySnake: x = Console.WindowWidth - 10; type = ElementType.EnemySnake; alt = Altitude.Low; break;
            case ElementType.EnemyNinja: x = Console.WindowWidth - 10; type = ElementType.EnemyNinja; alt = Altitude.Mid; break;
            case ElementType.EnemyDog: x = Console.WindowWidth - 10; type = ElementType.EnemyDog; alt = Altitude.Low; break;
            case ElementType.EnemyBat: x = Console.WindowWidth - 10; type = ElementType.EnemyBat; alt = Altitude.High; break;
            case ElementType.EnemyShooter: x = 70; type = ElementType.EnemyShooter; alt = Altitude.Mid; break;
            case ElementType.EnemyProjectile: x = 67; type = ElementType.EnemyProjectile; break;
        }
    }

    public static ConsoleColor PlayerColor  //property providing access to "playerColor" member
    {
        get { return playerColor; }
        set { playerColor = value; }
    }

    public static char ProjectileShape //property providing access to "projectileShape" member
    {
        get { return projectileShape; }
        set { projectileShape = value; }
    }

    public int Coordinate  //property providing access to "x" private member
    {
        get { return x; }
        set
        {
            if (Console.WindowWidth > value && 0 < value)
            {
                x = value;
            }
        }
    }

    public Altitude ElementState    //property providing access to "alt" private member
    {
        get { return alt; }
        set { alt = value; }
    }

    public ElementType Type  //property providing access to "type" private member
    {
        get { return type; }
    }

    public bool StepState  //property providing access to "step" private member
    {
        get { return step; }
    }

    public void Crouch()  //method used to change the state of the element to Low (crouched)
    {
        alt = Altitude.Low;
        stateTime = CrouchTime;
    }

    public void Jump()  //method used to change the state of the element to High (jumped)
    {
        alt = Altitude.High;
        stateTime = JumpTime;
    }

    public void Walk() //method used to reset the state of the element to Mid (walking)
    {
        alt = Altitude.Mid;
    }

    public bool StateCooldown()  //method returns the element is still in non-default state (jump,crouch)
    {
        if (stateTime == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool MakeStep()  //method used to rotate the step state of the element and to reduce the stateTime counter for non-default states, keeping the element in certain state predefined amount of time (game cycles)
    {
        step = !step;

        if (type == ElementType.Player)
        {
            if (stateTime == 0)
            {
                alt = Altitude.Mid;
            }
            else
            {
                stateTime--;
            }
        }

        return step;
    }

    public bool MakeStep(int spawnRate)   // overload for MakeStep method used for enemyes. It takes as parameter the spawnrate (that is defined int GameStatus class) in order determine the speed of the enemies
    {
        step = !step;

        if (type != ElementType.EnemyShooter)
        {
            x -= spawnRate;
        }

        return step;
    }

    public bool UpdateProjectile()  // method used to update the position of projectile type elements. Returns true if the element is outside of the console window and should be removed.
    {
        if (type == ElementType.PlayerProjectile)
        {
            x = x + 5;

            if (x >= Console.WindowWidth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            x = x - 5;

            if (x <= 0)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}

