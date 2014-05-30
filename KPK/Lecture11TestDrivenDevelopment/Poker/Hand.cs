namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        private IList<ICard> cards;
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

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder hand = new StringBuilder("Hand");

            if (this.cards.Count == 0)
            {
                hand.Append(" is empty.");
            }
            else
            {
                foreach (var card in this.cards)
                {
                    hand.Append(" | ");
                    hand.Append(card);
                }

                hand.Append(" |");
            }

            return hand.ToString();
        }
    }
}
