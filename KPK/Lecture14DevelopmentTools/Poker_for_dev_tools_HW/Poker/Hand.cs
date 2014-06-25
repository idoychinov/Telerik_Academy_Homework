//-----------------------------------------------------------------------
// <copyright file="Hand.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the Hand enumeration.</summary>
//-----------------------------------------------------------------------
namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A hand of cards (<see cref="Card"/>).
    /// </summary>
    public class Hand : IHand
    {
        /// <summary>
        /// List with cards in the hand.
        /// </summary>
        private IList<ICard> cards;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hand"/> class.
        /// </summary>
        /// <param name="cards">List of cards to initialize the hand with.</param>
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        /// <summary>
        /// Gets a copy of the list of cards within the current <see cref="Hand"/> object instance.
        /// </summary>
        /// <value>The list of cars in the hand.</value> 
        public IList<ICard> Cards
        {
            get
            {
                IList<ICard> cardsList = new List<ICard>();
                Card currentCard;
                foreach (var card in this.cards)
                {
                    currentCard = new Card(card.Face, card.Suit);
                    cardsList.Add(currentCard);
                }

                return cardsList;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cards in hand cannot be null");
                }

                this.cards = new List<ICard>();
                foreach (var card in value)
                {
                    Card currentCard;
                    currentCard = new Card(card.Face, card.Suit);
                    this.cards.Add(currentCard);
                }
            }
        }

        /// <summary>
        /// Returns a string representation of the hand.
        /// <example>
        /// This sample will write on the console the following: Hand: Ace of Spades, Two of Clubs
        /// <code>
        /// IHand hand = new Hand( new Card(CardFace.Ace, CardSuit.Spades), new Card (CardFace.Two, CardSuit.Clubs));
        /// Console.WriteLine(hand.ToString());
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>Returns the string representation of the cards in the hand or the string "Hand is empty." if the hand contains no cards.</returns>
        public override string ToString()
        {
            StringBuilder hand = new StringBuilder("Hand");

            if (this.cards.Count == 0)
            {
                hand.Append(" is empty.");
            }
            else
            {
                hand.Append(": ");
                foreach (var card in this.cards)
                {
                    hand.Append(card);
                    hand.Append(", ");
                }

                hand.Length = hand.Length - 2;
            }

            return hand.ToString();
        }
    }
}
