namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

            foreach (var card in CardTestUtilities.Faces)
            {
                cards.Add(new Card(card.Value, CardTestUtilities.Suits[1]));
                hand = new Hand(cards);
                if (cards.Count == 5)
                {
                    Assert.AreEqual(true, handChecker.IsValidHand(hand), "Valid 5 cards hand is considered as invalid by the method.");
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsValidHand(hand), "Invalid size hand is considered as invalid by the method.");
                }
            }
        }

        /// <summary>
        /// Tests all combinations of five different cards in hand and compares the result with the one returned from PokerHandsChecker.IsValidHand
        /// </summary>
        [TestMethod]
        public void TestIsValidHandForNoDuplicates()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                    Assert.AreEqual(true, handChecker.IsValidHand(hand.Key),
                        string.Format("Hand checker returns false for hand {0}", hand.Key));
                
            }
        }

        // TODO: test more combinations
        [TestMethod]
        public void TestIsValidForInvalidHand()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardTestUtilities.AllCards[0]),
                new Card(CardTestUtilities.AllCards[0]),
                new Card(CardTestUtilities.AllCards[0]),
                new Card(CardTestUtilities.AllCards[0]),
                new Card(CardTestUtilities.AllCards[0]),
            });

            IPokerHandsChecker handChecker = new PokerHandsChecker();
            Assert.AreEqual(false, handChecker.IsValidHand(hand),
                string.Format("Hand checker returns true for hand {0}", hand));
        }

        ///VERY SLOW 
        /// <summary>
        /// Tests all posible combinations of five card hand and compares the result with the one returned from PokerHandsChecker.IsValidHand
        /// WARNING! Very slow test. Runs around 1 hour on relativly fast computer.
        /// </summary>
        ////[TestMethod]
        ////public void TestIsValidHandAllCombinations()
        ////{
        ////    IList<ICard> cards;
        ////    IHand hand;
        ////    IPokerHandsChecker handChecker = new PokerHandsChecker();
        ////    bool allDifferentCardsInHand;
        ////    bool actual;
        ////    IList<ICard> allCards = CardTestUtilities.AllCards;

        ////    foreach (var firstCard in allCards)
        ////    {
        ////        foreach (var secondCard in allCards)
        ////        {
        ////            foreach (var thirdCard in allCards)
        ////            {
        ////                foreach (var forthCard in allCards)
        ////                {
        ////                    foreach (var fifthCard in allCards)
        ////                    {
        ////                        cards = new List<ICard>()
        ////                        {
        ////                            firstCard,
        ////                            secondCard,
        ////                            thirdCard,
        ////                            forthCard,
        ////                            fifthCard,
        ////                        };

        ////                        hand = new Hand(cards);

        ////                        allDifferentCardsInHand = CardTestUtilities.AllDifferentCards(
        ////                            firstCard,
        ////                            secondCard,
        ////                            thirdCard,
        ////                            forthCard,
        ////                            fifthCard
        ////                            );

        ////                        actual = handChecker.IsValidHand(hand);
        ////                        Assert.AreEqual(allDifferentCardsInHand,actual,
        ////                            string.Format("Hand checker returns incorect result for hand {0}", hand.ToString()));
        ////                    }
        ////                }
        ////            }
        ////        }
        ////    }
        ////}

        

        // TODO: Combine repeating tests 

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestIsFlushCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value==HandTypeEnumeration.Flush)
                {
                    Assert.AreEqual(true, handChecker.IsFlush(hand.Key),
                        string.Format("Flush returns false for flush hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsFlush(hand.Key),
                        string.Format("Flush returns true for non flush hand {0}", hand.Key));
                }
            }
        }

        [TestMethod]
        public void TestIsFourOfAKindCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value==HandTypeEnumeration.FourOfAKind)
                {
                    Assert.AreEqual(true, handChecker.IsFourOfAKind(hand.Key),
                        string.Format("IsFourOfAKind returns false for four of a kind hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsFourOfAKind(hand.Key),
                        string.Format("IsFourOfAKind returns true for non four of a kind hand {0}", hand.Key));
                }
            }
        }
        
        [TestMethod]
        public void TestIsOnePairCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value==HandTypeEnumeration.OnePair)
                {
                    Assert.AreEqual(true, handChecker.IsOnePair(hand.Key),
                        string.Format("IsOnePair returns false for one pair hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsOnePair(hand.Key),
                        string.Format("IsOnePair returns true for non one pair hand {0}", hand.Key));
                }
            }
        }

        [TestMethod]
        public void TestIsTwoPairCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value==HandTypeEnumeration.TwoPair)
                {
                    Assert.AreEqual(true, handChecker.IsTwoPair(hand.Key),
                        string.Format("TwoPair returns false for two pair hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsTwoPair(hand.Key),
                        string.Format("TwoPair returns true for non two pairhand {0}", hand.Key));
                }
            }
        }
        
        [TestMethod]
        public void TestIsThreeOfAKindCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value==HandTypeEnumeration.ThreeOfAKind)
                {
                    Assert.AreEqual(true, handChecker.IsThreeOfAKind(hand.Key),
                        string.Format("IsThreeOfAKind returns false for three of a kind hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsThreeOfAKind(hand.Key),
                        string.Format("IsThreeOfAKind returns true for non three of a kind hand {0}", hand.Key));
                }
            }
        }
        
        [TestMethod]
        public void TestIsFullHouseCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value==HandTypeEnumeration.FullHouse)
                {
                    Assert.AreEqual(true, handChecker.IsFullHouse(hand.Key),
                        string.Format("IsFullHouse returns false for Full House hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsFullHouse(hand.Key),
                        string.Format("IsFullHouse returns true for non Full House hand {0}", hand.Key));
                }
            }
        }

        [TestMethod]
        public void TestIsStraightCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value==HandTypeEnumeration.Straight)
                {
                    Assert.AreEqual(true, handChecker.IsStraight(hand.Key),
                        string.Format("IsStraight returns false for streight hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsStraight(hand.Key),
                        string.Format("IsStraight returns true for non streight hand {0}", hand.Key));
                }
            }
        }

        [TestMethod]
        public void TestIsStraightFlushCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value==HandTypeEnumeration.StraightFlush)
                {
                    Assert.AreEqual(true, handChecker.IsStraightFlush(hand.Key),
                        string.Format("IsStraightFlush returns false for streight flush hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsStraightFlush(hand.Key),
                        string.Format("IsStraightFlush returns true for non streight flush hand {0}", hand.Key));
                }
            }
        }


        [TestMethod]
        public void TestIsHighCardCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value==HandTypeEnumeration.HighCard)
                {
                    Assert.AreEqual(true, handChecker.IsHighCard(hand.Key),
                        string.Format("IsHighCard returns false for high card hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsHighCard(hand.Key),
                        string.Format("IsHighCard returns true for non high card hand {0}", hand.Key));
                }
            }
        }

        [TestMethod]
        public void TestAlIPokerHandCheckerMethodsForValidHandCheck()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsFlush(hand),
                string.Format("PokerHandsChecker.IsFlush returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(false, handChecker.IsFourOfAKind(hand),
                string.Format("PokerHandsChecker.IsFourOfAKind returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(false, handChecker.IsFullHouse(hand),
                string.Format("PokerHandsChecker.IsFullHouse returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(false, handChecker.IsHighCard(hand),
                string.Format("PokerHandsChecker.IsHighCard returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(false, handChecker.IsOnePair(hand),
                string.Format("PokerHandsChecker.IsOnePair returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(false, handChecker.IsStraight(hand),
                string.Format("PokerHandsChecker.IsStraight returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(false, handChecker.IsStraightFlush(hand),
                string.Format("PokerHandsChecker.IsStraightFlush returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(false, handChecker.IsThreeOfAKind(hand),
                string.Format("PokerHandsChecker.IsThreeOfAKind returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(false, handChecker.IsTwoPair(hand),
                string.Format("PokerHandsChecker.IsTwoPair returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(false, handChecker.CompareHands(hand,hand),
                string.Format("PokerHandsChecker.CompareHands returns true for non valid hand for hand {0}", hand.ToString()));
        }
        
        [TestMethod]
        public void TestCardTestUtilitiesHandTypesCorrectNumbersOfCombinations()
        {
            int currentTypeSelection;
            
            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandTypeEnumeration.StraightFlush).Count();
            Assert.AreEqual(40, currentTypeSelection, "Incorect number of Straight Flush combinations");
            
            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandTypeEnumeration.Flush).Count();
            Assert.AreEqual(5108, currentTypeSelection, "Incorect number of Flush combinations");
  
            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandTypeEnumeration.Straight).Count();
            Assert.AreEqual(10200, currentTypeSelection, "Incorect number of Straight combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandTypeEnumeration.FourOfAKind).Count();
            Assert.AreEqual(624, currentTypeSelection, "Incorect number of Four of a Kind combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandTypeEnumeration.FullHouse).Count();
            Assert.AreEqual(3744, currentTypeSelection, "Incorect number of Full House combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandTypeEnumeration.ThreeOfAKind).Count();
            Assert.AreEqual(54912, currentTypeSelection, "Incorect number of Three of a Kind combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandTypeEnumeration.TwoPair).Count();
            Assert.AreEqual(123552, currentTypeSelection, "Incorect number of Two pair combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandTypeEnumeration.OnePair).Count();
            Assert.AreEqual(1098240, currentTypeSelection, "Incorect number of One pair combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandTypeEnumeration.HighCard).Count();
            Assert.AreEqual(1302540, currentTypeSelection, "Incorect number of High card combinations");

        }
    }
}
