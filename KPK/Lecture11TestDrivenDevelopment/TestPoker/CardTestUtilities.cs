namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker;


    /// <summary>
    /// 
    /// Some of the optimizations were made after several tests were implemented so tests must be refactored to use the latest optimized
    /// methods and properties from this class.
    /// </summary>
    public static class CardTestUtilities
    {
        public static readonly Dictionary<int, CardFace> Faces = new Dictionary<int, CardFace>()
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

        public static readonly Dictionary<int, CardSuit> Suits = new Dictionary<int, CardSuit>()
        {
            {1,CardSuit.Clubs},
            {2,CardSuit.Diamonds},
            {3,CardSuit.Hearts},
            {4,CardSuit.Spades},
        };

        public static readonly IList<ICard> AllCards = GeneratAllCards();

        private static IList<ICard> GeneratAllCards()
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


        public static bool AllDifferentCards(params ICard[] cards)
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

        public static readonly IList<IHand> AllHands = GenerateAllHands();
        private static IList<IHand> GenerateAllHands()
        {
            IList<IHand> hands = new List<IHand>();

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
                                hands.Add(
                                new Hand
                                    (
                                    new List<ICard>()
                                    {
                                        new Card (CardTestUtilities.AllCards[firstCard]),
                                        new Card (CardTestUtilities.AllCards[secondCard]),
                                        new Card (CardTestUtilities.AllCards[thirdCard]),
                                        new Card (CardTestUtilities.AllCards[forthCard]),
                                        new Card (CardTestUtilities.AllCards[fifthCard]),
                                    }
                                    )
                                );
                            }
                        }
                    }
                }
            }

            return hands;
        }

        public static readonly IDictionary<IHand, Dictionary<string, bool>> HandTypes = GenerateHandTypes();

        private static IDictionary<IHand, Dictionary<string, bool>> GenerateHandTypes()
        {
            IDictionary<IHand, Dictionary<string, bool>> result = new Dictionary<IHand, Dictionary<string, bool>>();
            Dictionary<string, bool> handType;

            foreach (var hand in AllHands)
            {
                handType = new Dictionary<string, bool>();
                bool highCard = true;
                if (AllSameSuit(hand))
                {
                    handType["SameSuit"] = true;
                    highCard = false;
                }
                else
                {
                    handType["SameSuit"] = false;
                }

                if (FourOfAKind(hand))
                {
                    handType["FourOfAKind"] = true;
                    highCard = false;
                }
                else
                {
                    handType["FourOfAKind"] = false;
                }

                if (IsOnePair(hand))
                {
                    handType["OnePair"] = true;
                    highCard = false;
                }
                else
                {
                    handType["OnePair"] = false;
                }

                if (IsTwoPair(hand))
                {
                    handType["TwoPair"] = true;
                    highCard = false;
                }
                else
                {
                    handType["TwoPair"] = false;
                }

                if (ThreeOfAKind(hand))
                {
                    handType["ThreeOfAKind"] = true;
                    highCard = false;
                }
                else
                {
                    handType["ThreeOfAKind"] = false;
                }

                if (FullHouse(hand))
                {
                    handType["FullHouse"] = true;
                    highCard = false;
                }
                else
                {
                    handType["FullHouse"] = false;
                }

                if (Streight(hand))
                {
                    handType["Streight"] = true;
                    highCard = false;
                }
                else
                {
                    handType["Streight"] = false;
                }

                if (StreightFlush(hand))
                {
                    handType["StreightFlush"] = true;
                    highCard = false;
                }
                else
                {
                    handType["StreightFlush"] = false;
                }


                if (highCard)
                {
                    handType["HighCard"] = true;
                }
                else
                {
                    handType["HighCard"] = false;

                }

                result[hand] = handType;
            }

            return result;
        }

        private static bool AllSameSuit(IHand hand)
        {
            CardSuit suit = hand.Cards[0].Suit;
            foreach (var card in hand.Cards)
            {
                if (card.Suit != suit)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool FourOfAKind(IHand hand)
        {
            CardFace face = hand.Cards[0].Face;
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();

            foreach (var card in hand.Cards)
            {
                if (facesCount.ContainsKey(card.Face))
                {
                    facesCount[card.Face]++;
                }
                else
                {
                    facesCount[card.Face] = 1;
                }
            }

            foreach (var faceCount in facesCount)
            {
                if (faceCount.Value == 4)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsOnePair(IHand hand)
        {
            CardFace face = hand.Cards[0].Face;
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();

            foreach (var card in hand.Cards)
            {
                if (facesCount.ContainsKey(card.Face))
                {
                    facesCount[card.Face]++;
                }
                else
                {
                    facesCount[card.Face] = 1;
                }
            }

            if (facesCount.Values.Max() == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsTwoPair(IHand hand)
        {
            CardFace face = hand.Cards[0].Face;
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();

            foreach (var card in hand.Cards)
            {
                if (facesCount.ContainsKey(card.Face))
                {
                    facesCount[card.Face]++;
                }
                else
                {
                    facesCount[card.Face] = 1;
                }
            }

            if (facesCount.Values.Max() == 2)
            {
                int numberOfPairs = 0;
                foreach (var pair in facesCount)
                {
                    if (pair.Value == 2)
                    {
                        numberOfPairs++;
                    }
                }
                if (numberOfPairs == 2)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ThreeOfAKind(IHand hand)
        {
            CardFace face = hand.Cards[0].Face;
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();

            foreach (var card in hand.Cards)
            {
                if (facesCount.ContainsKey(card.Face))
                {
                    facesCount[card.Face]++;
                }
                else
                {
                    facesCount[card.Face] = 1;
                }
            }

            if (facesCount.Values.Max() == 3)
            {
                return true;
            }

            return false;
        }

        private static bool FullHouse(IHand hand)
        {
            CardFace face = hand.Cards[0].Face;
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();

            foreach (var card in hand.Cards)
            {
                if (facesCount.ContainsKey(card.Face))
                {
                    facesCount[card.Face]++;
                }
                else
                {
                    facesCount[card.Face] = 1;
                }
            }

            if (facesCount.Values.Contains(3) && facesCount.Values.Contains(2))
            {
                return true;
            }

            return false;
        }

        private static bool Streight(IHand hand)
        {
            if (AreSequential(hand) && !AllSameSuit(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool StreightFlush(IHand hand)
        {
            if (AreSequential(hand) && AllSameSuit(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool AreSequential(IHand hand)
        {
            CardFace face = hand.Cards[0].Face;
            IDictionary<CardFace, int> facesCount = new Dictionary<CardFace, int>();

            foreach (var card in hand.Cards)
            {
                if (facesCount.ContainsKey(card.Face))
                {
                    facesCount[card.Face]++;
                }
                else
                {
                    facesCount[card.Face] = 1;
                }
            }

            bool maxRepetitons = facesCount.Values.Max() == 1;
            int minFace = (int)facesCount.Keys.Min();
            int maxFace = (int)facesCount.Keys.Max();
            bool areSequence = maxFace - minFace == 4;

            if (maxRepetitons && areSequence)
            {
                return true;
            }

            return false;
        }
    }
}
