namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using Poker;

    public static class TestUtilities
    {
        public static readonly Dictionary<int, CardFace> Faces = new Dictionary<int, CardFace>()
        {
            {2,CardFace.Two},
            {3,CardFace.Three},
            {4,CardFace.Four},
            {5,CardFace.Five},
            {6,CardFace.Six},
            {7,CardFace.Seven},
            {8,CardFace.Eight},
            {9,CardFace.Nine},
            {10,CardFace.Ten},
            {11,CardFace.Jack},
            {12,CardFace.Queen},
            {13,CardFace.King},
            {14,CardFace.Ace},
        };

        public static readonly Dictionary<int, CardSuit> Suits = new Dictionary<int, CardSuit>()
        {
            {1,CardSuit.Clubs},
            {2,CardSuit.Diamonds},
            {3,CardSuit.Hearts},
            {4,CardSuit.Spades},
        };
    }
}
