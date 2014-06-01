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
            ICard card;
            for (int i = (int)CardFace.Two; i <= (int)CardFace.Ace; i++)
            {
                for (int j = (int)CardSuit.Clubs; j <= (int)CardSuit.Spades; j++)
                {
                    card = new Card((CardFace)i, (CardSuit)j);
                    Assert.AreEqual(CardTestUtilities.Faces[i], card.Face, "Card face of the new card is not correct");
                    Assert.AreEqual(CardTestUtilities.Suits[j], card.Suit, "Card suit of the new card is not correct");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidFaceGreaterThenCardFaceEnum()
        {
            ICard card = new Card((CardFace)15, CardSuit.Clubs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidFaceLessThenCardFaceEnum()
        {
            ICard card = new Card((CardFace)1, CardSuit.Clubs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidSuitGreaterThenCardSuitEnum()
        {
            ICard card = new Card(CardFace.Two, (CardSuit)0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidSuitLessThenCardSuitEnum()
        {
            ICard card = new Card(CardFace.Two, (CardSuit)5);
        }

        [TestMethod]
        public void TestCardToString()
        {
            ICard card;
            string cardName;
            for (int i = (int)CardFace.Two; i <= (int)CardFace.Ace; i++)
            {
                for (int j = (int)CardSuit.Clubs; j <= (int)CardSuit.Spades; j++)
                {
                    card = new Card((CardFace)i, (CardSuit)j);
                    cardName = string.Concat(((CardFace)i).ToString(), " of ", ((CardSuit)j).ToString());
                    Assert.AreEqual(cardName, card.ToString(), "Card name returned from ToString() is not correct");
                }
            }
        }

        [TestMethod]
        public void TestCardEqualsObject()
        {
            ICard firstCard;
            object secondCard;
            foreach (var currentCard in CardTestUtilities.AllCards)
            {
                firstCard = new Card(currentCard.Face, currentCard.Suit);
                secondCard = new Card(currentCard.Face, currentCard.Suit);
                Assert.AreEqual(true, firstCard.Equals(secondCard),
                    string.Format("Equals() returns false result for {0}.Equals({1})", firstCard, secondCard));
            }
        }

        [TestMethod]
        public void TestCardEqualsObjectNull()
        {
            ICard firstCard = new Card(CardTestUtilities.AllCards[0].Face, CardTestUtilities.AllCards[0].Suit);
            object secondCard = null;
            Assert.AreEqual(false, firstCard.Equals(secondCard),
                string.Format("Equals() returns true result for {0}.Equals({1})", firstCard, secondCard));
        }

        [TestMethod]
        public void TestCardEqualsCard()
        {
            Card firstCard;
            Card secondCard;
            foreach (var currentCard in CardTestUtilities.AllCards)
            {
                firstCard = new Card(currentCard.Face, currentCard.Suit);
                secondCard = new Card(currentCard.Face, currentCard.Suit);
                Assert.AreEqual(true, firstCard.Equals(secondCard),
                    string.Format("Equals() returns false result for {0}.Equals({1})", firstCard, secondCard));
            }
        }

        [TestMethod]
        public void TestCardEqualsCardNull()
        {
            Card firstCard = new Card(CardTestUtilities.AllCards[0].Face, CardTestUtilities.AllCards[0].Suit);
            Card secondCard = null;
            Assert.AreEqual(false, firstCard.Equals(secondCard),
                string.Format("Equals() returns true result for {0}.Equals({1})", firstCard, secondCard));
        }

        [TestMethod]
        public void TestCardNotEquals()
        {
            ICard firstCard = new Card(CardTestUtilities.AllCards[0].Face, CardTestUtilities.AllCards[0].Suit);
            ICard secondCard;
            for (var currentCard = 1; currentCard < CardTestUtilities.AllCards.Count; currentCard++)
            {
                secondCard = new Card(
                    CardTestUtilities.AllCards[currentCard].Face,
                    CardTestUtilities.AllCards[currentCard].Suit);
                Assert.AreEqual(false, firstCard.Equals(secondCard),
                    string.Format("Not Equal operator returns false result for {0}.Equals({1})", firstCard, secondCard));
            }
        }

        [TestMethod]
        public void TestCardHashCode()
        {
            ICard firstCard = new Card(CardTestUtilities.AllCards[0].Face, CardTestUtilities.AllCards[0].Suit);
            ICard secondCard;
            bool areEqual;
            int firstHash;
            int secondHash;
            for (var currentCard = 0; currentCard < CardTestUtilities.AllCards.Count; currentCard++)
            {
                secondCard = new Card(
                    CardTestUtilities.AllCards[currentCard].Face,
                    CardTestUtilities.AllCards[currentCard].Suit);
                areEqual = firstCard.Equals(secondCard);
                firstHash = firstCard.GetHashCode();
                secondHash = secondCard.GetHashCode();
                Assert.AreEqual(areEqual, firstHash == secondHash,
                    string.Format("GetHashCode function gives {0} results for cars : {1} and {2}",
                    areEqual ? "diferent" : "same", firstCard, secondCard));

            }
        }

        [TestMethod]
        public void TestCardCopyConstructor()
        {
            ICard firstCard = new Card(CardTestUtilities.AllCards[0].Face, CardTestUtilities.AllCards[0].Suit);
            ICard secondCard = new Card(firstCard);
            bool areEqual = (firstCard.Face == secondCard.Face)&& (firstCard.Suit == secondCard.Suit);
            
                Assert.AreEqual(true, areEqual,
                    string.Format("Copy constructur returns different values for suit and/or face of new card." +
                    " Original {0} ; new {0}", firstCard, secondCard));
        }
    }
}
