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
    using log4net;
    using log4net.Config;
    using System.Reflection;

    /// <summary>
    /// Poker Example class to test the Card, Hand and PokerHandChecker classes in the console.
    /// </summary>
    public class PokerExample
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Main method of the program.
        /// </summary>
        public static void Main()
        {
            XmlConfigurator.Configure();
            Log.Debug(string.Format("Application start {0:dd:mm:yyyy:hh:MM:ss}", DateTime.Now));
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Log.Info(string.Format("Card {0} created {1:dd:mm:yyyy:hh:MM:ss}",card, DateTime.Now));
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Log.Info(string.Format("Hand {0} created {1:dd:mm:yyyy:hh:MM:ss}",hand, DateTime.Now));
            Console.WriteLine(hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsValidHand(hand));
            Console.WriteLine(checker.IsOnePair(hand));
            Console.WriteLine(checker.IsTwoPair(hand));
        }
    }
}
