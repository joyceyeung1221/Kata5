using System;
using System.Collections.Generic;
using System.Linq;
namespace Blackjack
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public Deck()
        {
            Cards = new List<Card>();
            Random random = new Random();
            string[] suits = { "CLUB","DIAMOND","HEART","SPADE" };
            string[] listOfCardNames = { "2", "3", "4", "5", "6", "7", "8", "9", "Jack", "Queen", "King", "Ace" };
            var listOfCards = new List<Card>();
            foreach (string suit in suits)
            {
                foreach(string cardName in listOfCardNames)
                {
                    Cards.Add(new Card(suit, cardName));
                }
            }
            Cards = Cards.OrderBy(card => random.Next(0,Cards.Count-1)).ToList();
        }

        public Card HandOutCard()
        {
            var card = this.Cards.Last();
            this.Cards.Remove(this.Cards.Last());
            return card;
        }


    }
}
