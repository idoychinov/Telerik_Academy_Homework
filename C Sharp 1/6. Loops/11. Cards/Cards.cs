/* Problem 11. Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). The cards should be printed with their English names. Use nested for loops and switch-case.
 */
using System;

class Cards
{
    static void Main()
    {
        string rank="", suit="";
       

        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0: suit = "Spades"; break;
                case 1: suit = "Hearts"; break;
                case 2: suit = "Diamonds"; break;
                case 3: suit = "Clubs"; break;
            }
            for (int j = 1; j < 14; j++)
            {
                switch (j)
                {
                    case 1: rank = "Ace"; break;
                    case 2: rank = "Two"; break;
                    case 3: rank = "Three"; break;
                    case 4: rank = "Four"; break;
                    case 5: rank = "Five"; break;
                    case 6: rank = "Six"; break;
                    case 7: rank = "Seven"; break;
                    case 8: rank = "Eight"; break;
                    case 9: rank = "Nine"; break;
                    case 10: rank = "Ten"; break;
                    case 11: rank = "Jack"; break;
                    case 12: rank = "Queen"; break;
                    case 13: rank = "King"; break;
                }
                Console.WriteLine(rank+" of "+ suit);
            }
        }
    }
}

