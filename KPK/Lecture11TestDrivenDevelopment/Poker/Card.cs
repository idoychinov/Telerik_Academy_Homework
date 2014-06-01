﻿namespace Poker
{
    using System;

    public class Card : ICard
    {
        private CardFace face;
        private CardSuit suit;

        public CardFace Face
        {
            get
            {
                return this.face;
            }
            private set
            {
                if (2 > (int)value || (int)value > 14)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Value for card face {0} is invalid.", value));
                }

                this.face = value;
            }
        }

        public CardSuit Suit
        {
            get
            {
                return this.suit;
            }
            private set
            {
                if (1 > (int)value || (int)value > 4)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Value for card suit {0} is invalid.", value));
                }

                this.suit = value;
            }
        }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public Card(ICard card)
        {
            this.Face = card.Face;
            this.Suit = card.Suit;
        }

        public override string ToString()
        {
            return this.face + " of " + this.suit;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ICard card = obj as ICard;
            if ((Object)card == null)
            {
                return false;
            }

            return (this.Face == card.Face && this.Suit == card.Suit);
        }

        public bool Equals(Card card)
        {
            if ((Object)card == null)
            {
                return false;
            }

            return (this.Face == card.Face && this.Suit == card.Suit);
        }

        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + ((int)this.Face).GetHashCode();
            result = prime * result + ((int)this.Suit).GetHashCode();
            return result;
        }
    }
}
