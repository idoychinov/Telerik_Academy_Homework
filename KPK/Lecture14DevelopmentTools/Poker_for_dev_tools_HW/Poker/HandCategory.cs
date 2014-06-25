//-----------------------------------------------------------------------
// <copyright file="HandCategory.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the HandCategory enumeration.</summary>
//-----------------------------------------------------------------------
namespace Poker
{
    /// <summary>
    /// Enumeration containing all type of wining hands in poker.
    /// </summary>
    public enum HandCategory
    {
        /// <summary>
        /// The card with highest face determines the hand's strength.
        /// </summary>
        HighCard = 0,

        /// <summary>
        /// One pair of cards with equal faces in the hand.
        /// </summary>
        OnePair = 1,

        /// <summary>
        /// Two pairs of cards with equal faces in the hand.
        /// </summary>
        TwoPair = 2,

        /// <summary>
        /// Three cards with equal faces in the hand.
        /// </summary>
        ThreeOfAKind = 3,

        /// <summary>
        /// Five cards with sequential faces in the hand.
        /// </summary>
        Straight = 4,

        /// <summary>
        /// Five cards with the same suit in the hand.
        /// </summary>
        Flush = 5,

        /// <summary>
        /// Three cards with equal faces and two other cards with equal faces in the hand.
        /// </summary>
        FullHouse = 6,

        /// <summary>
        /// Four cards with equal faces in the hand.
        /// </summary>
        FourOfAKind = 7,

        /// <summary>
        /// Five cards with sequential faces all with the same suit in the hand.
        /// </summary>
        StraightFlush = 8
    }
}
