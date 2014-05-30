namespace TestPoker
{

    using System;
    using System.Collections.Generic;
    using Poker;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCard
    {
        private Dictionary<int, CardFace> faces = new Dictionary<int, CardFace>()
        {
            {2,CardFace.Two},
            {3,CardFace.Three},
            {4,CardFace.Four},
            {5,CardFace.Five},
            {6,CardFace.Six},
            {7,CardFace.Seven},
            {8,CardFace.Eight},
            {9,CardFace.Nine},
            {10,CardFace.Ten},
            {11,CardFace.Jack},
            {12,CardFace.Queen},
            {13,CardFace.King},
            {14,CardFace.Ace},
        };

        private Dictionary<int, CardSuit> suits = new Dictionary<int, CardSuit>()
        {
            {1,CardSuit.Clubs},
            {2,CardSuit.Diamonds},
            {3,CardSuit.Hearts},
            {4,CardSuit.Spades},
        };

        [TestMethod]
        public void TestCardCreation()
        {
            Card card;
            for (int i =(int)CardFace.Two; i <= (int)CardFace.Ace; i++)
            {
                for (int j = (int)CardSuit.Clubs; j <= (int)CardSuit.Spades; j++)
                {
                    card = new Card((CardFace)i, (CardSuit)j);
                    Assert.AreEqual(faces[i], card.Face, "Card face of the new card is not correct");
                    Assert.AreEqual(suits[j], card.Suit, "Card suit of the new card is not correct");
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
