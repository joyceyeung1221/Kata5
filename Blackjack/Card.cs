using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class Card
    {
        public string Name { get; private set; }
        public string Suit { get; private set; }
        public int Value { get; private set; }

        public static Dictionary<string, int> cardValue = new Dictionary<string, int>
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

        public string getDisplayName()
        {
            string displayName = Name;
            if (new string[] { "King", "Queen", "Jack", "Ace" }.Contains(Name))
            {
                displayName = $"'{this.Name}'";
            }
            return displayName

        }



        public Card(string suit, string name)
        {
            Name = name;
            Suit = suit;
            Value = cardValue[name];
        }
    }
}
