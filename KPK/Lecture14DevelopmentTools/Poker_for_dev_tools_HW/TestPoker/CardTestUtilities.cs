//-----------------------------------------------------------------------
// <copyright file="CardTestUtilities.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the CardTestUtilities class.</summary>
//-----------------------------------------------------------------------
namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker;

    /// <summary>
    /// Class containing the necessary utilities for building the unit tests for the Poker project.
    /// Some of the optimizations were made after several tests were implemented so tests must be refactored to use the latest optimized
    /// methods and properties from this class.
    /// </summary>
    public static class CardTestUtilities
    {
        /// <summary>
        /// Dictionary containing all possible card faces.
        /// </summary>
        public static readonly Dictionary<int, Poker.CardFace> Faces = new Dictionary<int, Poker.CardFace>()
        {
            { 2, CardFace.Two },
            { 3, CardFace.Three },
            { 4, CardFace.Four },
            { 5, CardFace.Five },
            { 6, CardFace.Six },
            { 7, CardFace.Seven },
            { 8, CardFace.Eight },
            { 9, CardFace.Nine },
            { 10, CardFace.Ten },
            { 11, CardFace.Jack },
            { 12, CardFace.Queen },
            { 13, CardFace.King },
            { 14, CardFace.Ace },
        };

        /// <summary>
        /// Dictionary containing all possible card suits.
        /// </summary>
        public static readonly Dictionary<int, Poker.CardSuit> Suits = new Dictionary<int, Poker.CardSuit>()
        {
            { 1, CardSuit.Clubs },
            { 2, CardSuit.Diamonds },
            { 3, CardSuit.Hearts },
            { 4, CardSuit.Spades },
        };

        /// <summary>
        /// List containing all the 52 cards in a poker game.
        /// </summary>
        public static readonly IList<Poker.ICard> AllCards = GeneratAllCards();

        /// <summary>
        /// Dictionary containing all possible valid combinations of poker hands. 
        /// The key is the hand and the value is HandCategory type for this hand.
        /// </summary>
        public static readonly IDictionary<Poker.IHand, Poker.HandCategory> AllHandsAndTypes = GenerateAllHandsAndTypes();

        /// <summary>
        /// Checks if all cards passed as a parameter array are different.
        /// </summary>
        /// <param name="cards">Array or comma separated parameters with all the cards to check.</param>
        /// <returns>Returns true if all cards are different, and false if there is at least one repeating card.</returns>
        public static bool AllDifferentCards(params Poker.ICard[] cards)
        {
            for (int cardChecked = 0; cardChecked < cards.Length; cardChecked++)
            {
                for (int otherCard = cardChecked + 1; otherCard < cards.Length; otherCard++)
                {
                    if (cards[cardChecked] == cards[otherCard])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Generates a list of all the 52 cards in poker game.
        /// </summary>
        /// <returns>List of all valid cards.</returns>
        private static IList<Poker.ICard> GeneratAllCards()
        {
            IList<ICard> cardsList = new List<ICard>();
            foreach (var cardFace in CardTestUtilities.Faces)
            {
                foreach (var cardSuit in CardTestUtilities.Suits)
                {
                    cardsList.Add(new Card(cardFace.Value, cardSuit.Value));
                }
            }

            return cardsList;
        }

        /// <summary>
        /// Generates a dictionary containing all possible valid combinations of poker hands.
        /// </summary>
        /// <returns>Dictionary containing all valid poker hands. 
        /// The key is the hand and the value is HandCategory type for this hand.</returns>
        private static IDictionary<Poker.IHand, Poker.HandCategory> GenerateAllHandsAndTypes()
        {
            IDictionary<IHand, HandCategory> hands = new Dictionary<IHand, HandCategory>();
            HandCategory handType;
            IHand hand;
            for (var firstCard = 0; firstCard < CardTestUtilities.AllCards.Count; firstCard++)
            {
                for (var secondCard = firstCard + 1; secondCard < CardTestUtilities.AllCards.Count; secondCard++)
                {
                    for (var thirdCard = secondCard + 1; thirdCard < CardTestUtilities.AllCards.Count; thirdCard++)
                    {
                        for (var forthCard = thirdCard + 1; forthCard < CardTestUtilities.AllCards.Count; forthCard++)
                        {
                            for (var fifthCard = forthCard + 1; fifthCard < CardTestUtilities.AllCards.Count; fifthCard++)
                            {
                                handType = HandCategory.HighCard;
                                bool allSequential =
                                    (((firstCard / 4) + 4) == (fifthCard / 4)) &&
                                    (((secondCard / 4) + 3) == (fifthCard / 4)) &&
                                    (((thirdCard / 4) + 2) == (fifthCard / 4)) &&
                                    (((forthCard / 4) + 1) == (fifthCard / 4));

                                bool lowCardAce = (firstCard / 4 == 0) && (secondCard / 4 == 1) &&
                                    (thirdCard / 4 == 2) && (forthCard / 4 == 3) && (fifthCard / 4 == 12);

                                allSequential = allSequential || lowCardAce;

                                bool oneSuit =
                                    ((firstCard % 4) == (fifthCard % 4)) &&
                                    ((secondCard % 4) == (fifthCard % 4)) &&
                                    ((thirdCard % 4) == (fifthCard % 4)) &&
                                    ((forthCard % 4) == (fifthCard % 4));

                                int[] cardRanks = new int[]
                                    {
                                        firstCard / 4,
                                        secondCard / 4,
                                        thirdCard / 4,
                                        forthCard / 4,
                                        fifthCard / 4
                                    };

                                IDictionary<int, int> countOfRepetitions = new Dictionary<int, int>();

                                foreach (var rank in cardRanks)
                                {
                                    if (countOfRepetitions.ContainsKey(rank))
                                    {
                                        countOfRepetitions[rank]++;
                                    }
                                    else
                                    {
                                        countOfRepetitions[rank] = 1;
                                    }
                                }

                                bool fourOfAKind = countOfRepetitions.Values.Contains(4);
                                bool fullHouse = countOfRepetitions.Values.Contains(3) && countOfRepetitions.Values.Contains(2);
                                bool threeOfKind = countOfRepetitions.Values.Contains(3);
                                bool twoPair = countOfRepetitions.Where(x => x.Value == 2).Count() == 2;
                                bool onePair = countOfRepetitions.Values.Contains(2);

                                if (allSequential)
                                {
                                    if (oneSuit)
                                    {
                                        handType = HandCategory.StraightFlush;
                                    }
                                    else
                                    {
                                        handType = HandCategory.Straight;
                                    }
                                }
                                else if (oneSuit)
                                {
                                    handType = HandCategory.Flush;
                                }
                                else if (fourOfAKind)
                                {
                                    handType = HandCategory.FourOfAKind;
                                }
                                else if (fullHouse)
                                {
                                    handType = HandCategory.FullHouse;
                                }
                                else if (threeOfKind)
                                {
                                    handType = HandCategory.ThreeOfAKind;
                                }
                                else if (twoPair)
                                {
                                    handType = HandCategory.TwoPair;
                                }
                                else if (onePair)
                                {
                                    handType = HandCategory.OnePair;
                                }

                                hand = new Hand(
                                        new List<ICard>()
                                        {
                                            new Card(CardTestUtilities.AllCards[firstCard]),
                                            new Card(CardTestUtilities.AllCards[secondCard]),
                                            new Card(CardTestUtilities.AllCards[thirdCard]),
                                            new Card(CardTestUtilities.AllCards[forthCard]),
                                            new Card(CardTestUtilities.AllCards[fifthCard]),
                                        });

                                hands.Add(hand, handType);
                            }
                        }
                    }
                }
            }

            return hands;
        }
    }
}
