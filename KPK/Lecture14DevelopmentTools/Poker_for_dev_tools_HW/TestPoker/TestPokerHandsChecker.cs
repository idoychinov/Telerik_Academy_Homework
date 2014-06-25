//-----------------------------------------------------------------------
// <copyright file="TestPokerHandsChecker.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the TestPokerHandsChecker class.</summary>
//-----------------------------------------------------------------------
namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    /// <summary>
    /// Class for testing the <see cref="PokerHandsChecker"/> class.
    /// </summary>
    [TestClass]
    public class TestPokerHandsChecker
    {
        /// <summary>
        /// Tests if a hand is with valid size.
        /// </summary>
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
        /// Tests all combinations of five different cards in hand and compares the result with the one returned from PokerHandsChecker.IsValidHand().
        /// </summary>
        [TestMethod]
        public void TestIsValidHandForNoDuplicates()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                Assert.AreEqual(
                    true, 
                    handChecker.IsValidHand(hand.Key),
                    string.Format("Hand checker returns false for hand {0}", hand.Key));
            }
        }

        /// <summary>
        /// Tests if IsValid() returns false for invalid hand.
        /// </summary>
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
            Assert.AreEqual(
                false,
                handChecker.IsValidHand(hand),
                string.Format("Hand checker returns true for hand {0}", hand));
        }

        // TODO: Combine repeating tests 

        /// <summary>
        /// Test IsFlush() for all Flush combinations.
        /// </summary>
        [TestMethod]
        public void TestIsFlushCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value == HandCategory.Flush)
                {
                    Assert.AreEqual(
                        true,
                        handChecker.IsFlush(hand.Key),
                        string.Format("Flush returns false for flush hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(
                        false,
                        handChecker.IsFlush(hand.Key),
                        string.Format("Flush returns true for non flush hand {0}", hand.Key));
                }
            }
        }

        /// <summary>
        /// Test IsFourOfAKind() for all Four of a kind combinations.
        /// </summary>
        [TestMethod]
        public void TestIsFourOfAKindCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value == HandCategory.FourOfAKind)
                {
                    Assert.AreEqual(
                        true,
                        handChecker.IsFourOfAKind(hand.Key),
                        string.Format("IsFourOfAKind returns false for four of a kind hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(
                        false, 
                        handChecker.IsFourOfAKind(hand.Key),
                        string.Format("IsFourOfAKind returns true for non four of a kind hand {0}", hand.Key));
                }
            }
        }

        /// <summary>
        /// Test IsOnePair() for all One pair combinations.
        /// </summary>
        [TestMethod]
        public void TestIsOnePairCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value == HandCategory.OnePair)
                {
                    Assert.AreEqual(
                        true, 
                        handChecker.IsOnePair(hand.Key),
                        string.Format("IsOnePair returns false for one pair hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(
                        false,
                        handChecker.IsOnePair(hand.Key),
                        string.Format("IsOnePair returns true for non one pair hand {0}", hand.Key));
                }
            }
        }

        /// <summary>
        /// Test IsTwoPair() for all Two pair combinations.
        /// </summary>
        [TestMethod]
        public void TestIsTwoPairCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value == HandCategory.TwoPair)
                {
                    Assert.AreEqual(
                        true, 
                        handChecker.IsTwoPair(hand.Key),
                        string.Format("TwoPair returns false for two pair hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(
                        false,
                        handChecker.IsTwoPair(hand.Key),
                        string.Format("TwoPair returns true for non two pairhand {0}", hand.Key));
                }
            }
        }

        /// <summary>
        /// Test IsThreeOfAKind() for all Three of a kind combinations.
        /// </summary>
        [TestMethod]
        public void TestIsThreeOfAKindCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value == HandCategory.ThreeOfAKind)
                {
                    Assert.AreEqual(
                        true,
                        handChecker.IsThreeOfAKind(hand.Key),
                        string.Format("IsThreeOfAKind returns false for three of a kind hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(
                        false,
                        handChecker.IsThreeOfAKind(hand.Key),
                        string.Format("IsThreeOfAKind returns true for non three of a kind hand {0}", hand.Key));
                }
            }
        }

        /// <summary>
        /// Test IsFullHouse() for all Full house combinations.
        /// </summary>
        [TestMethod]
        public void TestIsFullHouseCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value == HandCategory.FullHouse)
                {
                    Assert.AreEqual(
                        true, 
                        handChecker.IsFullHouse(hand.Key),
                        string.Format("IsFullHouse returns false for Full House hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(
                        false, 
                        handChecker.IsFullHouse(hand.Key),
                        string.Format("IsFullHouse returns true for non Full House hand {0}", hand.Key));
                }
            }
        }

        /// <summary>
        /// Test IsStraight() for all Straight combinations.
        /// </summary>
        [TestMethod]
        public void TestIsStraightCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value == HandCategory.Straight)
                {
                    Assert.AreEqual(
                        true,
                        handChecker.IsStraight(hand.Key),
                        string.Format("IsStraight returns false for streight hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(
                        false,
                        handChecker.IsStraight(hand.Key),
                        string.Format("IsStraight returns true for non streight hand {0}", hand.Key));
                }
            }
        }

        /// <summary>
        /// Test IsStraightFlush() for all Straight flush combinations.
        /// </summary>
        [TestMethod]
        public void TestIsStraightFlushCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value == HandCategory.StraightFlush)
                {
                    Assert.AreEqual(
                        true,
                        handChecker.IsStraightFlush(hand.Key),
                        string.Format("IsStraightFlush returns false for streight flush hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(
                        false,
                        handChecker.IsStraightFlush(hand.Key),
                        string.Format("IsStraightFlush returns true for non streight flush hand {0}", hand.Key));
                }
            }
        }

        /// <summary>
        /// Test IsSHighCard() for all High card combinations.
        /// </summary>
        [TestMethod]
        public void TestIsHighCardCorrectCombinations()
        {
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            foreach (var hand in CardTestUtilities.AllHandsAndTypes)
            {
                if (hand.Value == HandCategory.HighCard)
                {
                    Assert.AreEqual(
                        true, 
                        handChecker.IsHighCard(hand.Key),
                        string.Format("IsHighCard returns false for high card hand {0}", hand.Key));
                }
                else
                {
                    Assert.AreEqual(
                        false,
                        handChecker.IsHighCard(hand.Key),
                        string.Format("IsHighCard returns true for non high card hand {0}", hand.Key));
                }
            }
        }

        /// <summary>
        /// Tests if all PokerHandChecker methods check for valid hand.
        /// </summary>
        [TestMethod]
        public void TestAlIPokerHandCheckerMethodsForValidHandCheck()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card(CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(
                false, 
                handChecker.IsFlush(hand),
                string.Format("PokerHandsChecker.IsFlush returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(
                false, 
                handChecker.IsFourOfAKind(hand),
                string.Format("PokerHandsChecker.IsFourOfAKind returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(
                false,
                handChecker.IsFullHouse(hand),
                string.Format("PokerHandsChecker.IsFullHouse returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(
                false, 
                handChecker.IsHighCard(hand),
                string.Format("PokerHandsChecker.IsHighCard returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(
                false, 
                handChecker.IsOnePair(hand),
                string.Format("PokerHandsChecker.IsOnePair returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(
                false,
                handChecker.IsStraight(hand),
                string.Format("PokerHandsChecker.IsStraight returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(
                false, 
                handChecker.IsStraightFlush(hand),
                string.Format("PokerHandsChecker.IsStraightFlush returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(
                false,
                handChecker.IsThreeOfAKind(hand),
                string.Format("PokerHandsChecker.IsThreeOfAKind returns true for non valid hand for hand {0}", hand.ToString()));

            Assert.AreEqual(
                false,
                handChecker.IsTwoPair(hand),
                string.Format("PokerHandsChecker.IsTwoPair returns true for non valid hand for hand {0}", hand.ToString()));
        }

        /// <summary>
        /// Tests if compare hands throw exception correctly for invalid hand.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "PokerHandsChecker.CompareHands doesn't return exception for invalid hand")]
        public void TestCompareHandsIvalidHand()
        {
            IList<ICard> cards = new List<ICard>() 
            {
                new Card(CardTestUtilities.AllCards[0])
            };
            IHand hand = new Hand(cards);
            IPokerHandsChecker handChecker = new PokerHandsChecker();
            handChecker.CompareHands(hand, hand);
        }

        /// <summary>
        /// Test CompareHands() for High card hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsHighCardFirstHandWin()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for High card hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsHighCardSecondHandWin()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(-1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for High card hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsHighCardEqualHands()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(0, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for One pair hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsOnePairFirstHandWins()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for One pair hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsOnePairSecondHandWinsByHigh()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(-1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for One pair hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsOnePairEqual()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(0, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for Two pair hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsTwoPairFirstWins()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for Three of a kind hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsThreeOfAKindSecondHandWins()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(-1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for Straight hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsStraightSecondHandWins()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(-1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for Flush hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsFlushFirstHandWins()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for Full House hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsFullHouseSecondHandWins()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(-1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for Four of a kind hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsFourOfAKindSecondHandWins()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(-1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test CompareHands() for Straight flush hands.
        /// </summary>
        [TestMethod]
        public void TestCompareHandsStraightFlushFirstHandWins()
        {
            IList<ICard> cards;
            cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
            };
            IHand firstHand = new Hand(cards);

            cards = new List<ICard>() 
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
            };

            IHand secondHand = new Hand(cards);

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(1, handChecker.CompareHands(firstHand, secondHand), "CompareHands returns wrong result");
        }

        /// <summary>
        /// Test if CardTestUtilities.AllHandsAndTypes contains the correct number of combinations for each hand type.
        /// </summary>
        [TestMethod]
        public void TestCardTestUtilitiesHandTypesCorrectNumbersOfCombinations()
        {
            int currentTypeSelection;

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandCategory.StraightFlush).Count();
            Assert.AreEqual(40, currentTypeSelection, "Incorect number of Straight Flush combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandCategory.Flush).Count();
            Assert.AreEqual(5108, currentTypeSelection, "Incorect number of Flush combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandCategory.Straight).Count();
            Assert.AreEqual(10200, currentTypeSelection, "Incorect number of Straight combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandCategory.FourOfAKind).Count();
            Assert.AreEqual(624, currentTypeSelection, "Incorect number of Four of a Kind combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandCategory.FullHouse).Count();
            Assert.AreEqual(3744, currentTypeSelection, "Incorect number of Full House combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandCategory.ThreeOfAKind).Count();
            Assert.AreEqual(54912, currentTypeSelection, "Incorect number of Three of a Kind combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandCategory.TwoPair).Count();
            Assert.AreEqual(123552, currentTypeSelection, "Incorect number of Two pair combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandCategory.OnePair).Count();
            Assert.AreEqual(1098240, currentTypeSelection, "Incorect number of One pair combinations");

            currentTypeSelection = CardTestUtilities.AllHandsAndTypes
                .Where(hands => hands.Value == HandCategory.HighCard).Count();
            Assert.AreEqual(1302540, currentTypeSelection, "Incorect number of High card combinations");
        }
    }
}
