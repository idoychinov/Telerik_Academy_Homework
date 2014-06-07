//-----------------------------------------------------------------------
// <copyright file="IHand.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the IHand interface.</summary>
//-----------------------------------------------------------------------
namespace Poker
{
    using System.Collections.Generic;

    /// <summary>
    /// IHand interface. Describes all methods and properties needed for an object to be considered a hand of cards.
    /// </summary>
    public interface IHand
    {
        /// <summary>
        /// Gets the list of cards in the hand.
        /// </summary>
        /// <value>Returns a copy of the list of all cards in the hand.</value>
        IList<ICard> Cards { get; }

        /// <summary>
        /// String representation of the hand.
        /// </summary>
        /// <returns>String containing string representation of all the cards in the hand.</returns>
        string ToString();
    }
}
