using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Card
    {
        static Dictionary<string, int> cardValue;
        public string Name { get; private set; }
        public string Suit { get; private set; }
        public int Value { get; private set; }

        static Card()
        {
            cardValue = new Dictionary<string, int>
            {
                { "1", 1 },
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "Jack", 10 },
                { "King", 10 },
                { "Queen", 10 },
                { "Ace", 0 },
            };
        }

        public Card(string suit, string name)
        {
            Name = name;
            Suit = suit;
            Value = cardValue[name];
        }
    }
}
