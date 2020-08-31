using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class Player
    {
        protected const int waitTimeInms = 2000;

        public List<Card> Hand { get; set; }

        public int Score { get; set; }

        public bool Isdealer { get; set; }

        public Player(bool isDealer = false)
        {
            Hand = new List<Card>();
            Score = 0;
            Isdealer = isDealer;
        }

        public void TakeCard(Card card)
        {
            this.Hand.Add(card);
        }

        public int UpdateScore(int score)
        {
            return Score = score;
        }

        public void CompleteTurns(int maxScore, Deck deck, BlackJackEngine blackJackEngine)
        {
            int playerMove;
            write($"\n{blackJackEngine.ConfirmPlayerStatus(this)}\n");

            while (Score < maxScore)
            {
                playerMove = blackJackEngine.GetPlayerNextMove();
                if (playerMove == 1)
                {
                    var currentCard = deck.HandOutCard();
                    TakeCard(currentCard);
                    write($"\nYou draw [{currentCard.getDisplayName()}, '{currentCard.Suit}']\n");
                    wait();
                    UpdateScore(ScoreTracker.CalculateScore(this.Hand));
                    write($"\n{blackJackEngine.ConfirmPlayerStatus(this)}\n");
                }
                else { break; }
            }
        }

        protected void write(string text)
        {
            Console.Write(text);
        }

        protected void wait(int ms = waitTimeInms)
        {
            System.Threading.Thread.Sleep(ms);
        }
    }
}