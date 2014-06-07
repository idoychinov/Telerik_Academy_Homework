//-----------------------------------------------------------------------
// <copyright file="Card.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the Card class.</summary>
//-----------------------------------------------------------------------
namespace Poker
{
    using System;

    /// <summary>
    /// Card object from standard 52 cards deck.
    /// </summary>
    public class Card : ICard
    {
        /// <summary>
        /// Card face ( two, three, King, Ace, etc.).
        /// </summary>
        private CardFace face;

        /// <summary>
        /// Cards suit ( Clubs, Diamonds, Hearts, Spades).
        /// </summary>
        private CardSuit suit;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="face">The card's face.</param>
        /// <param name="suit">The card's suit.</param>
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class as a copy of an existing <see cref="Card"/> object instance.
        /// </summary>
        /// <param name="card">Card object instance.</param>
        public Card(ICard card)
        {
            this.Face = card.Face;
            this.Suit = card.Suit;
        }

        /// <summary>
        /// Gets the value of the card face ( two, three, King, Ace, etc.).
        /// </summary>
        /// <value>The card face.</value>
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

        /// <summary>
        /// Gets the value of the card suit ( Clubs, Diamonds, Hearts, Spades).
        /// </summary>
        /// <value>The card suit.</value>
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

        /// <summary>
        /// Returns a string representation of the card.
        /// <example>
        /// This sample will write on the console the following:  Ace of Spades
        /// <code>
        /// ICard card = new Card(CardFace.Ace, CardSuit.Spades);
        /// Console.WriteLine(card.ToString());
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>Card's face and suit values as string.</returns>
        public override string ToString()
        {
            return this.face + " of " + this.suit;
        }

        /// <summary>
        /// Compares if two cards are equal. The comparison is by value of the two card components - face and suit.
        /// </summary>
        /// <param name="obj">Object to compare with.</param>
        /// <returns>True if the cards are equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ICard card = obj as ICard;
            if ((object)card == null)
            {
                return false;
            }

            return this.Face == card.Face && this.Suit == card.Suit;
        }

        /// <summary>
        /// Compares if two cards are equal. The comparison is by value of the two card components - face and suit.
        /// </summary>
        /// <param name="card">The card to compare with.</param>
        /// <returns>True if the cards are equal.</returns>
        public bool Equals(Card card)
        {
            if ((object)card == null)
            {
                return false;
            }

            return this.Face == card.Face && this.Suit == card.Suit;
        }

        /// <summary>
        /// Gets the hash code of a card. For two non equal cards the hash codes will be different.
        /// </summary>
        /// <returns>Card's hash code.</returns>
        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = (prime * result) + ((int)this.Face).GetHashCode();
            result = (prime * result) + ((int)this.Suit).GetHashCode();
            return result;
        }
    }
}
