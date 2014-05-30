namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using Poker;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestPokerHandsChecker
    {
        [TestMethod]
        public void TestIsValidHandForSize()
        {
            IList<ICard> cards = new List<ICard>();
            IHand hand;
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            foreach (var card in TestUtilities.Faces)
            {
                cards.Add(new Card(card.Value, TestUtilities.Suits[0]));
                hand = new Hand(cards);
                if(cards.Count == 5){
                    Assert.AreEqual(true,handChecker.IsValidHand(hand),"Valid 5 cards hand is considered as invalid by the method.");
                }
                else
                {
                    Assert.AreEqual(false,handChecker.IsValidHand(hand),"Invalid size hand is considered as invalid by the method.");
                }
            }
        }

        [TestMethod]
        public void TestIsValidHandSize()
        {
            IList<ICard> cards;
            IHand hand;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            bool allDifferentCardsInHand;

            foreach (var firstCard in GeneratAllCards())
            {
                foreach (var secondCard in GeneratAllCards())
                {
                    foreach (var thirdCard in GeneratAllCards())
                    {
                        foreach (var forthCard in GeneratAllCards())
                        {
                            foreach (var fifthCard in GeneratAllCards())
                            {
                                cards = new List<ICard>()
                                {
                                    firstCard,
                                    secondCard,
                                    thirdCard,
                                    forthCard,
                                    fifthCard,
                                };

                                hand = new Hand(cards);

                                allDifferentCardsInHand = AllDifferentCards();
                            }
                        }
                    }
                }
            }
            

        }

        private IList<ICard> GeneratAllCards()
        {
            IList<ICard> cardsList = new List<ICard>();
            foreach (var cardFace in TestUtilities.Faces)
            {
                foreach (var cardSuit in TestUtilities.Suits)
                {
                    cardsList.Add(new Card(cardFace.Value,cardSuit.Value));
                }
            }

            return cardsList;
        }

        private bool AllDifferentCards(params Card[] cards)
        {
            return false;
        }
    }
}
