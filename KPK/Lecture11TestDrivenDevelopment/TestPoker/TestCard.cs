namespace TestPoker
{

    using System;
    using System.Collections.Generic;
    using Poker;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCard
    {

        [TestMethod]
        public void TestCardCreation()
        {
            Card card;
            for (int i =(int)CardFace.Two; i <= (int)CardFace.Ace; i++)
            {
                for (int j = (int)CardSuit.Clubs; j <= (int)CardSuit.Spades; j++)
                {
                    card = new Card((CardFace)i, (CardSuit)j);
                    Assert.AreEqual(TestUtilities.Faces[i], card.Face, "Card face of the new card is not correct");
                    Assert.AreEqual(TestUtilities.Suits[j], card.Suit, "Card suit of the new card is not correct");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidFaceGreaterThenCardFaceEnum()
        {
            Card card = new Card((CardFace)15, CardSuit.Clubs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidFaceLessThenCardFaceEnum()
        {
            Card card = new Card((CardFace)1, CardSuit.Clubs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidSuitGreaterThenCardSuitEnum()
        {
            Card card = new Card(CardFace.Two, (CardSuit)0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidSuitLessThenCardSuitEnum()
        {
            Card card = new Card(CardFace.Two, (CardSuit)5);
        }

        [TestMethod]
        public void TestCardToString()
        {
            Card card;
            string cardName;
            for (int i =(int)CardFace.Two; i <= (int)CardFace.Ace; i++)
            {
                for (int j = (int)CardSuit.Clubs; j <= (int)CardSuit.Spades; j++)
                {
                    card = new Card((CardFace)i, (CardSuit)j);
                    cardName = string.Concat(((CardFace)i).ToString(), " of ", ((CardSuit)j).ToString());
                    Assert.AreEqual(cardName, card.ToString(), "Card name returned from ToString() is not correct");
                }
            }
        }
    }
}
