//-----------------------------------------------------------------------
// <copyright file="PokerExample.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the PokerExample class.</summary>
//-----------------------------------------------------------------------
namespace Poker
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Poker Example class to test the Card, Hand and PokerHandChecker classes in the console.
    /// </summary>
    public class PokerExample
    {
        /// <summary>
        /// Main method of the program.
        /// </summary>
        public static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine(hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsValidHand(hand));
            Console.WriteLine(checker.IsOnePair(hand));
            Console.WriteLine(checker.IsTwoPair(hand));
        }
    }
}
