//-----------------------------------------------------------------------
// <copyright file="IPokerHandsChecker.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the IPokerHandsChecker interface.</summary>
//-----------------------------------------------------------------------
namespace Poker
{
    /// <summary>
    /// Interface for checking poker hands as defined in http://en.wikipedia.org/wiki/List_of_poker_hands.
    /// </summary>
    public interface IPokerHandsChecker
    {
        /// <summary>
        /// Checks if a hand is valid poker hand.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is valid poker hand.</returns>
        bool IsValidHand(IHand hand);

        /// <summary>
        /// Checks if a hand is in the Straight flush category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Straight flush.</returns>
        bool IsStraightFlush(IHand hand);

        /// <summary>
        /// Checks if a hand is in the Four of a kind category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Four of a kind.</returns>
        bool IsFourOfAKind(IHand hand);

        /// <summary>
        /// Checks if a hand is in the Full house category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Full house.</returns>
        bool IsFullHouse(IHand hand);

        /// <summary>
        /// Checks if a hand is in the Flush category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Flush.</returns>
        bool IsFlush(IHand hand);

        /// <summary>
        /// Checks if a hand is in the Straight category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Straight.</returns>
        bool IsStraight(IHand hand);

        /// <summary>
        /// Checks if a hand is in the Three of a kind category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Three of a kind.</returns>
        bool IsThreeOfAKind(IHand hand);

        /// <summary>
        /// Checks if a hand is in the Two pair category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is Two pair.</returns>
        bool IsTwoPair(IHand hand);

        /// <summary>
        /// Checks if a hand is in the One pair category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is One pair.</returns>
        bool IsOnePair(IHand hand);

        /// <summary>
        /// Checks if a hand is in the High Card category.
        /// </summary>
        /// <param name="hand">Hand to be checked.</param>
        /// <returns>True if the hand is High Card.</returns>
        bool IsHighCard(IHand hand);

        /// <summary>
        /// Compares which one of two poker hands is the winning hand.
        /// </summary>
        /// <param name="firstHand">First poker hand.</param>
        /// <param name="secondHand">Second poker hand.</param>
        /// <returns>Returns 1 if the first hand is the winning hand or -1 if the second is the winning hand or 0 if both hands are equal.</returns>
        int CompareHands(IHand firstHand, IHand secondHand);
    }
}
