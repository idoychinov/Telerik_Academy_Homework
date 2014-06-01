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
            IList<ICard> cards;
            IHand hand;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            IList<ICard> allCards = CardTestUtilities.AllCards;

            for (var firstCard = 0; firstCard < allCards.Count; firstCard++)
            {
                for (var secondCard = firstCard + 1; secondCard < allCards.Count; secondCard++)
                {
                    for (var thirdCard = secondCard + 1; thirdCard < allCards.Count; thirdCard++)
                    {
                        for (var forthCard = thirdCard + 1; forthCard < allCards.Count; forthCard++)
                        {
                            for (var fifthCard = forthCard + 1; fifthCard < allCards.Count; fifthCard++)
                            {
                                cards = new List<ICard>()
                                {
                                    allCards[firstCard],
                                    allCards[secondCard],
                                    allCards[thirdCard],
                                    allCards[forthCard],
                                    allCards[fifthCard],
                                };

                                hand = new Hand(cards);
                                Assert.AreEqual(true, handChecker.IsValidHand(hand),
                                    string.Format("Hand checker returns false for hand {0}", hand.ToString()));
                            }
                        }
                    }
                }
            }
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

        [TestMethod]
        public void TestIsIsFlushNotValidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsFlush(hand),
                string.Format("PokerHandsChecker.IsFlush returns true for non valid hand for hand {0}", hand.ToString()));
        }

        /// <summary>
        /// WARNING slow test - runs around 30 sec on relativly fast computer.
        /// </summary>
        [TestMethod]
        public void TestIsFlushCorrectCombinations()
        {
            IList<IHand> hands = CardTestUtilities.AllHands;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            bool allSameSuit;
            CardSuit suit;
            foreach (var hand in hands)
            {
                suit = hand.Cards[0].Suit;
                allSameSuit = true;
                foreach (var card in hand.Cards)
                {
                    if (card.Suit != suit)
                    {
                        allSameSuit = false;
                        break;
                    }
                }

                if (allSameSuit)
                {
                    Assert.AreEqual(true, handChecker.IsFlush(hand), string.Format("IsFlush returns false for flush hand {0}", hand));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsFlush(hand), string.Format("IsFlush returns true for non flush hand {0}", hand));

                }
            }
        }

        [TestMethod]
        public void TestIsIsFourOfAKindNotValidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsFourOfAKind(hand),
                string.Format("PokerHandsChecker.IsFourOfAKind returns true for non valid hand for hand {0}", hand.ToString()));
        }

        [TestMethod]
        public void TestIsFourOfAKindCorrectCombinations()
        {
            IList<IHand> hands = CardTestUtilities.AllHands;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();
            foreach (var hand in CardTestUtilities.HandTypes)
            {
                if (hand.Value["FourOfAKind"])
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
        public void TestIsOnePairValidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsOnePair(hand),
                string.Format("PokerHandsChecker.IsOnePair returns true for non valid hand for hand {0}", hand.ToString()));
        }

        [TestMethod]
        public void TestIsOnePairCorrectCombinations()
        {
            IList<IHand> hands = CardTestUtilities.AllHands;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();
            foreach (var hand in CardTestUtilities.HandTypes)
            {
                if (hand.Value["OnePair"])
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
        public void TestIsTwoPairValidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsTwoPair(hand),
                string.Format("PokerHandsChecker.IsTwoPair returns true for non valid hand for hand {0}", hand.ToString()));
        }

        [TestMethod]
        public void TestIsTwoPairCorrectCombinations()
        {
            IList<IHand> hands = CardTestUtilities.AllHands;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();
            foreach (var hand in CardTestUtilities.HandTypes)
            {
                if (hand.Value["TwoPair"])
                {
                    Assert.AreEqual(true, handChecker.IsTwoPair(hand.Key),
                        string.Format("IsTwoPair returns false for two pair hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsTwoPair(hand.Key),
                        string.Format("IsTwoPair returns true for non two pair hand {0}", hand.Key));

                }

            }
        }

        [TestMethod]
        public void TestIsThreeOfAKindValidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsThreeOfAKind(hand),
                string.Format("PokerHandsChecker.IsThreeOfAKind returns true for non valid hand for hand {0}", hand.ToString()));
        }

        [TestMethod]
        public void TestIsThreeOfAKindCombinations()
        {
            IList<IHand> hands = CardTestUtilities.AllHands;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();
            foreach (var hand in CardTestUtilities.HandTypes)
            {
                if (hand.Value["ThreeOfAKind"])
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
        public void TestIsFullHouseNotValidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsFullHouse(hand),
                string.Format("IsFullHouse returns true for non valid hand for hand {0}", hand.ToString()));
        }

        [TestMethod]
        public void TestIsFullHouseCorrectCombinations()
        {
            IList<IHand> hands = CardTestUtilities.AllHands;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();
            foreach (var hand in CardTestUtilities.HandTypes)
            {
                if (hand.Value["FullHouse"])
                {
                    Assert.AreEqual(true, handChecker.IsFullHouse(hand.Key),
                        string.Format("IsFullHouse returns false for full house hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsFullHouse(hand.Key),
                        string.Format("IsFullHouse returns true for non full house hand {0}", hand.Key));

                }

            }
        }

        [TestMethod]
        public void TestIsStraightNotValidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsStraight(hand),
                string.Format("IsStraight returns true for non valid hand for hand {0}", hand.ToString()));
        }

        [TestMethod]
        public void TestIsStraightCorrectCombinations()
        {
            IList<IHand> hands = CardTestUtilities.AllHands;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();
            foreach (var hand in CardTestUtilities.HandTypes)
            {
                if (hand.Value["Streight"])
                {
                    Assert.AreEqual(true, handChecker.IsStraight(hand.Key),
                        string.Format("IsFullHouse returns false for streight hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsStraight(hand.Key),
                        string.Format("IsStraight returns true for non streight hand {0}", hand.Key));

                }

            }
        }

        [TestMethod]
        public void TestIsStraightFlushNotValidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsStraightFlush(hand),
                string.Format("IsStraightFlush returns true for non valid hand for hand {0}", hand.ToString()));
        }

        [TestMethod]
        public void TestIsStraightFlushCorrectCombinations()
        {
            IList<IHand> hands = CardTestUtilities.AllHands;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();
            foreach (var hand in CardTestUtilities.HandTypes)
            {
                if (hand.Value["StraightFlush"])
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
        public void TestIsIsHighCardNotValidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card (CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(false, handChecker.IsFlush(hand),
                string.Format("PokerHandsChecker.IsFourOfAKind returns true for non valid hand for hand {0}", hand.ToString()));
        }

        [TestMethod]
        public void TestIsHighCardCorrectCombinations()
        {
            IList<IHand> hands = CardTestUtilities.AllHands;
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();
            foreach (var hand in CardTestUtilities.HandTypes)
            {
                if (hand.Value["HighHand"])
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



        // Need to change the combination generation functions in order to recieve the correct results here.
        ////[TestMethod]
        ////public void TestCardTestUtilitiesHandTypesCorrectNumbersOfCombinations()
        ////{
        ////    Dictionary<string, int> handCombinations = new Dictionary<string, int>();
        ////    int currentTypeSelection;
        ////    currentTypeSelection = CardTestUtilities.HandTypes
        ////        .Where(hands => hands.Value["OnePair"] == true).Count();
                
        ////    Assert.AreEqual(1098240, currentTypeSelection, "Incorect number of One Pair combinations");



        ////}
    }
}
