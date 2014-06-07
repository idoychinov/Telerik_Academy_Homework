//-----------------------------------------------------------------------
// <copyright file="PokerHandsChecker.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the PokerHandsChecker class.</summary>
//-----------------------------------------------------------------------
namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class used for checking poker hands based on the <see cref="IpokerHandsChecker"/> interface.
    /// </summary>
    public class PokerHandsChecker : IPokerHandsChecker
    {
        /// <summary>
        /// The valid poker hand contains 5 cards.
        /// </summary>
        private const int ValidHandLength = 5;

        /// <summary>
        /// The maximum value of the <see cref="CardFace"/> enumeration.
        /// </summary>
        private const int FaceMaxCount = 14;

        /// <summary>
        /// The maximum value of the <see cref="CardSuit"/> enumeration.
        /// </summary>
        private const int SuitMaxCount = 4;

        /// <summary>
        /// Checks if a hand is valid poker hand.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is valid poker hand.</returns>
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != ValidHandLength)
            {
                return false;
            }

            HashSet<ICard> cardSet = new HashSet<ICard>();

            foreach (var card in hand.Cards)
            {
                if (!cardSet.Add(card))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if a hand is in the Straight flush category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Straight flush.</returns>
        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            CardSuit suit = hand.Cards[0].Suit;
            for (int i = 1; i < ValidHandLength; i++)
            {
                if (hand.Cards[i].Suit != suit)
                {
                    return false;
                }
            }

            int[] count = new int[FaceMaxCount + 1];

            for (int i = 0; i < ValidHandLength; i++)
            {
                if ((int)hand.Cards[i].Face == 14)
                {
                    count[1] += 1;
                }

                count[(int)hand.Cards[i].Face] += 1;
            }

            if (count.Max() != 1)
            {
                return false;
            }

            bool startFound = false;
            int currentLength = 0;
            for (int i = 1; i < count.Length; i++)
            {
                if (count[i] == 1)
                {
                    if (startFound)
                    {
                        currentLength++;
                        if (currentLength == 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        startFound = true;
                        currentLength++;
                    }
                }
                else
                {
                    startFound = false;
                    currentLength = 0;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a hand is in the Four of a kind category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Four of a kind.</returns>
        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            int[] count = new int[FaceMaxCount + 1];

            for (int i = 0; i < ValidHandLength; i++)
            {
                count[(int)hand.Cards[i].Face] += 1;
            }

            if (count.Max() >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a hand is in the Full house category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Full house.</returns>
        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            int[] count = new int[FaceMaxCount + 1];

            for (int i = 0; i < ValidHandLength; i++)
            {
                count[(int)hand.Cards[i].Face] += 1;
            }

            if (count.Max() == 3)
            {
                foreach (var item in count)
                {
                    if (item == 2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a hand is in the Flush category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Flush.</returns>
        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            CardSuit suit = hand.Cards[0].Suit;
            for (int i = 1; i < ValidHandLength; i++)
            {
                if (hand.Cards[i].Suit != suit)
                {
                    return false;
                }
            }

            if (this.IsStraightFlush(hand))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if a hand is in the Straight category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Straight.</returns>
        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            CardSuit suit = hand.Cards[0].Suit;
            bool sameSuit = true;
            for (int i = 1; i < ValidHandLength; i++)
            {
                if (hand.Cards[i].Suit != suit)
                {
                    sameSuit = false;
                }
            }

            if (sameSuit)
            {
                return false;
            }

            int[] count = new int[FaceMaxCount + 1];

            for (int i = 0; i < ValidHandLength; i++)
            {
                if ((int)hand.Cards[i].Face == 14)
                {
                    count[1] += 1;
                }

                count[(int)hand.Cards[i].Face] += 1;
            }

            if (count.Max() != 1)
            {
                return false;
            }

            bool startFound = false;
            int currentLength = 0;
            for (int i = 1; i < count.Length; i++)
            {
                if (count[i] == 1)
                {
                    if (startFound)
                    {
                        currentLength++;
                        if (currentLength == 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        startFound = true;
                        currentLength++;
                    }
                }
                else
                {
                    startFound = false;
                    currentLength = 0;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a hand is in the Three of a kind category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Three of a kind.</returns>
        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            int[] count = new int[FaceMaxCount + 1];

            for (int i = 0; i < ValidHandLength; i++)
            {
                count[(int)hand.Cards[i].Face] += 1;
            }

            if (count.Max() == 3 && !count.Contains(2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a hand is in the Two pair category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Two pair.</returns>
        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            int[] count = new int[FaceMaxCount + 1];

            for (int i = 0; i < ValidHandLength; i++)
            {
                count[(int)hand.Cards[i].Face] += 1;
            }

            if (count.Max() == 2)
            {
                int numberOfPairs = 0;
                foreach (var item in count)
                {
                    if (item == 2)
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

        /// <summary>
        /// Checks if a hand is in the One pair category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is One pair.</returns>
        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            int[] count = new int[FaceMaxCount + 1];

            for (int i = 0; i < ValidHandLength; i++)
            {
                count[(int)hand.Cards[i].Face] += 1;
            }

            Array.Sort(count);
            Array.Reverse(count);
            if (count[0] == 2 && count[1] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a hand is in the High Card category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is High Card.</returns>
        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.IsOnePair(hand) || this.IsTwoPair(hand) || this.IsThreeOfAKind(hand) ||
                this.IsStraight(hand) || this.IsFlush(hand) || this.IsFullHouse(hand) ||
                this.IsFourOfAKind(hand) || this.IsStraightFlush(hand))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares which one of two poker hands is the winning hand.
        /// </summary>
        /// <param name="firstHand">First poker hand.</param>
        /// <param name="secondHand">Second poker hand.</param>
        /// <returns>Returns 1 if the first hand is the winning hand or -1 if the second is the winning hand or 0 if both hands are equal.</returns>
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            HandCategory firstHandCategory = this.GetHandCategory(firstHand);
            HandCategory secondHandCategory = this.GetHandCategory(secondHand);

            if ((int)firstHandCategory > (int)secondHandCategory)
            {
                return 1;
            }
            else if ((int)secondHandCategory > (int)firstHandCategory)
            {
                return -1;
            }
            else
            {
                switch (firstHandCategory)
                {
                    case HandCategory.HighCard:
                        return this.CheckHighestCardInHand(firstHand, secondHand);
                    case HandCategory.OnePair:
                        return this.HighesHand(firstHand, secondHand, 2);
                    case HandCategory.TwoPair:
                        return this.HighesHand(firstHand, secondHand, 2);
                    case HandCategory.ThreeOfAKind:
                        return this.HighesHand(firstHand, secondHand, 3);
                    case HandCategory.Straight:
                        return this.CompareStraights(firstHand, secondHand);
                    case HandCategory.Flush:
                        return this.CheckHighestCardInHand(firstHand, secondHand);
                    case HandCategory.FullHouse:
                        return this.HighesHand(firstHand, secondHand, 3);
                    case HandCategory.FourOfAKind:
                        return this.HighesHand(firstHand, secondHand, 4);
                    case HandCategory.StraightFlush:
                        return this.CompareStraights(firstHand, secondHand);
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// Compares which one of two Straight hands is the winning hand. 
        /// </summary>
        /// <param name="firstHand">The first Straight hand.</param>
        /// <param name="secondHand">The second Straight hand.</param>
        /// <returns>Returns 1 if the first hand is the winning hand or -1 if the second is the winning hand or 0 if both hands are equal.</returns>
        private int CompareStraights(IHand firstHand, IHand secondHand)
        {
            bool isLowStraightFirstHand = firstHand.Cards.Where(x => x.Face == CardFace.Ace).Count() > 0 &&
                            firstHand.Cards.Where(x => x.Face == CardFace.Two).Count() > 0;
            bool isLowStraightSecondHand = secondHand.Cards.Where(x => x.Face == CardFace.Ace).Count() > 0 &&
                firstHand.Cards.Where(x => x.Face == CardFace.Two).Count() > 0;
            if (isLowStraightFirstHand && isLowStraightSecondHand)
            {
                return 0;
            }
            else if (isLowStraightFirstHand)
            {
                return -1;
            }
            else if (isLowStraightSecondHand)
            {
                return 1;
            }
            else
            {
                return this.CheckHighestCardInHand(firstHand, secondHand);
            }
        }

        /// <summary>
        /// Compares which one of two hands is the winning hand based on the number of cards with equal faces.
        /// </summary>
        /// <param name="firstHand">The first hand.</param>
        /// <param name="secondHand">The second hand.</param>
        /// <param name="repeats">The biggest number of repeating card faces in the hand.</param>
        /// <returns>Returns 1 if the first hand is the winning hand or -1 if the second is the winning hand or 0 if both hands are equal.</returns>
        private int HighesHand(IHand firstHand, IHand secondHand, int repeats)
        {
            int result = 0;
            IHand highestHandPartOne;
            IHand highestHandPartTwo;
            highestHandPartOne = this.GetRepeatingCardsFace(firstHand, repeats);
            highestHandPartTwo = this.GetRepeatingCardsFace(secondHand, repeats);
            result = this.CheckHighestCardInHand(highestHandPartOne, highestHandPartTwo);

            if (result == 0)
            {
                IList<ICard> lowHandPartOne = new List<ICard>(firstHand.Cards);
                IList<ICard> lowHandPartTwo = new List<ICard>(secondHand.Cards);
                foreach (var card in highestHandPartOne.Cards)
                {
                    lowHandPartOne.Remove(card);
                }

                foreach (var card in highestHandPartTwo.Cards)
                {
                    lowHandPartTwo.Remove(card);
                }

                return this.CheckHighestCardInHand(new Hand(lowHandPartOne), new Hand(lowHandPartTwo));
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Returns a new hand containing only cards with equal faces based on the number of repetitions of those cards in the hand.
        /// If there are more than one type of faces, for example two pairs both pairs will be returned.
        /// </summary>
        /// <param name="hand">The original hand.</param>
        /// <param name="repetition">The required number of repeating card faces in the hand.</param>
        /// <returns>New hand containing cards with equal faces that are repeated in the original hand 
        /// exactly <paramref name ="repetition"/> number of times.</returns>
        private IHand GetRepeatingCardsFace(IHand hand, int repetition)
        {
            IList<ICard> cards = new List<ICard>(hand.Cards);
            IList<ICard> cardsToAdd = new List<ICard>();
            IList<ICard> faces = new List<ICard>();

            while (cards.Count > 0)
            {
                cardsToAdd.Clear();
                int currentCard = 1;
                while (currentCard < cards.Count)
                {
                    if (cards[0].Face == cards[currentCard].Face)
                    {
                        cardsToAdd.Add(cards[currentCard]);
                    }

                    currentCard++;
                    if (currentCard >= cards.Count)
                    {
                        if (cardsToAdd.Count > 0)
                        {
                            if (cardsToAdd.Count + 1 == repetition)
                            {
                                foreach (var card in cardsToAdd)
                                {
                                    faces.Add(card);
                                    cards.Remove(card);
                                }

                                faces.Add(cards[0]);
                            }
                            else
                            {
                                foreach (var card in cardsToAdd)
                                {
                                    cards.Remove(card);
                                }
                            }
                        }
                    }
                }

                cards.Remove(cards[0]);
            }

            return new Hand(faces);
        }

        /// <summary>
        /// Compares which one of two hands is the winning hand.
        /// </summary>
        /// <param name="firstHand">The first hand.</param>
        /// <param name="secondHand">The second hand.</param>
        /// <returns>Returns 1 if the first hand is the winning hand or -1 if the second is the winning hand or 0 if both hands are equal.</returns>
        private int CheckHighestCardInHand(IHand firstHand, IHand secondHand)
        {
            int[] firstHandStrength = new int[FaceMaxCount + 1];

            for (int i = 0; i < firstHand.Cards.Count; i++)
            {
                firstHandStrength[(int)firstHand.Cards[i].Face] += 1;
            }

            int[] secondHandStrength = new int[FaceMaxCount + 1];

            for (int i = 0; i < secondHand.Cards.Count; i++)
            {
                secondHandStrength[(int)secondHand.Cards[i].Face] += 1;
            }

            for (int i = FaceMaxCount; i > 1; i--)
            {
                if (firstHandStrength[i] > secondHandStrength[i])
                {
                    return 1;
                }
                else if (firstHandStrength[i] < secondHandStrength[i])
                {
                    return -1;
                }
            }

            return 0;
        }

        /// <summary>
        /// Returns the Hand Category type of a poker hand.
        /// </summary>
        /// <param name="hand">A poker hand.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the hand is not a valid poker hand.</exception>
        /// <returns>HandCategory enumeration value describing the type of hand.</returns>
        private HandCategory GetHandCategory(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentOutOfRangeException("The Hand is not valid");
            }

            if (this.IsStraightFlush(hand))
            {
                return HandCategory.StraightFlush;
            }

            if (this.IsFourOfAKind(hand))
            {
                return HandCategory.FourOfAKind;
            }

            if (this.IsFullHouse(hand))
            {
                return HandCategory.FullHouse;
            }

            if (this.IsFlush(hand))
            {
                return HandCategory.Flush;
            }

            if (this.IsStraight(hand))
            {
                return HandCategory.Straight;
            }

            if (this.IsThreeOfAKind(hand))
            {
                return HandCategory.ThreeOfAKind;
            }

            if (this.IsTwoPair(hand))
            {
                return HandCategory.TwoPair;
            }

            if (this.IsOnePair(hand))
            {
                return HandCategory.OnePair;
            }

            if (this.IsHighCard(hand))
            {
                return HandCategory.HighCard;
            }

            throw new ArgumentException("The Hand is not in any of the recognized categoryes");
        }
    }
}
