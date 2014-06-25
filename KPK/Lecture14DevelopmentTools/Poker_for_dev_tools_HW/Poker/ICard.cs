//-----------------------------------------------------------------------
// <copyright file="ICard.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the ICard interface.</summary>
//-----------------------------------------------------------------------
namespace Poker
{
    /// <summary>
    /// ICard interface. Describes all methods and properties needed for an object to be considered a card.
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// Gets the card face.
        /// </summary>
        /// <value>The card's face.</value>
        CardFace Face { get; }

        /// <summary>
        /// Gets the card suit.
        /// </summary>
        /// <value>The card's suite.</value>
        CardSuit Suit { get; }

        /// <summary>
        /// String representation of the card.
        /// </summary>
        /// <returns>String with the card face and suit.</returns>
        string ToString();
    }
}
