namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int ValidHandLength = 5;
        private const int FaceMaxCount = 14;
        private const int SuitMaxCount = 4;

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

        public bool IsStraightFlush(IHand hand)
        {
            if(this.IsFlush(hand) && this.IsStraight(hand))
            {
                return true;
            }

            return false;
        }

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

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand) || this.IsFlush(hand))
            {
                return false;
            }

            int[] count = new int[FaceMaxCount + 1];

            for (int i = 0; i < ValidHandLength; i++)
            {
                count[(int)hand.Cards[i].Face] += 1;
            }

            if(count.Max() != 1)
            {
                return false;
            }

            bool startFound=false;
            int currentLength=0;
            for (int i = 0; i < count.Length; i++)
            {
                if(count[i]==1)
                {
                    if(startFound)
                    {
                        currentLength++;
                        if(currentLength ==5)
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

            if (count.Max() == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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

            if (count.Max() == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
