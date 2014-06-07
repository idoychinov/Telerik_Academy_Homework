//-----------------------------------------------------------------------
// <copyright file="TestHand.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the TestHand class.</summary>
//-----------------------------------------------------------------------
namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    /// <summary>
    /// Class for testing the <see cref="Hand"/> class.
    /// </summary>
    [TestClass]
    public class TestHand
    {
        /// <summary>
        /// Tests if new hand is created correctly.
        /// </summary>
        [TestMethod]
        public void TestNewHand()
        {
            IList<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Clubs)
                };

            Hand hand = new Hand(cards);
        }

        /// <summary>
        /// Testing if the private cards object we create in the constructor 
        /// (and from there to the setter) is not accessible through the object we passed 
        /// on the constructor, and the private property cards is encapsulated correctly.
        /// </summary>
        [TestMethod]
        public void TestSetHandAsNewObject()
        {
            IList<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Clubs)
                };

            Hand hand = new Hand(cards);
            cards.Clear();
            string errorMessage = "The constructor does not creat new object but assigns the value passed to the setter by refference" +
                ", exposing the privet member cards, and breaking encapsulation";
            Assert.AreEqual(1, hand.Cards.Count, errorMessage);
        }

        /// <summary>
        /// Testing if the object we get from the getter is new object and the private
        /// property cards is encapsulated correctly. 
        /// </summary>
        [TestMethod]
        public void TestGetHandAsNewObject()
        {
            IList<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Clubs)
                };

            Hand hand = new Hand(cards);
            IList<ICard> testCard = hand.Cards;
            Assert.AreEqual(
                false,
                object.ReferenceEquals(hand.Cards, testCard),
                "The getter returns the private object cards, not a new object.");
        }

        /// <summary>
        /// Testing assigning null to the card parameter of the constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The Cards property setter allows null value.")]
        public void TestHandConstructorErrorForNullParameter()
        {
            Hand hand = new Hand(null);
        }

        /// <summary>
        /// Testing if the output string is correct when the hand is empty.
        /// </summary>
        [TestMethod]
        public void TestHandToStringForEmptyHand()
        {
            IList<ICard> cards = new List<ICard>();

            Hand hand = new Hand(cards);
            Assert.AreEqual("Hand is empty.", hand.ToString(), "Incorect ToString value for empty hand");
        }

        /// <summary>
        /// Testing if the output string is correct for one card in the hand for all hand types.
        /// </summary>
        [TestMethod]
        public void TestHandToStringForOneCardInHand()
        {
            Hand hand;
            IList<ICard> cards;

            foreach (var cardFace in CardTestUtilities.Faces)
            {
                foreach (var cardSuit in CardTestUtilities.Suits)
                {
                    cards = new List<ICard>()
                    {
                        new Card(cardFace.Value, cardSuit.Value),
                    };

                    hand = new Hand(cards);
                    Assert.AreEqual(
                        "Hand: " + cardFace.Value.ToString() + " of " + cardSuit.Value.ToString(),
                        hand.ToString(),
                        string.Format("Incorect ToString return value for one card in hand."));
                }
            }
        }

        /// <summary>
        /// Testing if the output string is correct for all cards in the hand.
        /// </summary>
        [TestMethod]
        public void TestHandToStringForAllCardsInOneHand()
        {
            Hand hand;
            IList<ICard> cards = new List<ICard>();
            StringBuilder outputString = new StringBuilder();
            outputString.Append("Hand: ");

            foreach (var cardFace in CardTestUtilities.Faces)
            {
                foreach (var cardSuit in CardTestUtilities.Suits)
                {
                    cards.Add(new Card(cardFace.Value, cardSuit.Value));
                    outputString.Append(cardFace.Value.ToString() + " of " + cardSuit.Value.ToString() + ", ");
                }
            }

            outputString.Length = outputString.Length - 2;

            hand = new Hand(cards);
            Assert.AreEqual(outputString.ToString(), hand.ToString(), "Incorect ToString return value for all cards in hand.");
        }
    }
}
