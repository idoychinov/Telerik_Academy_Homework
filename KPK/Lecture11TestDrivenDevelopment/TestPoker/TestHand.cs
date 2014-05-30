namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using Poker;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestHand
    {
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
        /// Testing if the object we get from the getter is new object and the private
        /// property cards is encapsulated corectly. 
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
            Assert.AreEqual(false, object.ReferenceEquals(hand.Cards, testCard), 
                "The getter returns the private object cards, not a new object.");

        }

        /// <summary>
        /// Testing if the private cards object we create in the constructor 
        /// (and from there to the setter) is not accessible through the object we passed 
        /// on the constructor, and the private property cards is encapsulated corectly.
        /// </summary>
        [TestMethod]
        public void TestSetHandAsNewObject()
        {
            IList<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Clubs)
                };

            Hand hand = new Hand(cards);
            ICard testCard = hand.Cards[0];
            Assert.AreEqual(false, object.ReferenceEquals(hand.Cards[0], cards), 
                "The getter returns the private object cards, not a new object.");
        }
    }
}
