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

        public bool IsDealer { get; set; }

        public Player(bool isDealer = false)
        {
            Hand = new List<Card>();
            Score = 0;
            IsDealer = isDealer;
        }

        public void TakeCard(Card card)
        {
            this.Hand.Add(card);
        }

        public int UpdateScore(int score)
        {
            return Score = score;
        }

        public void CompleteTurns(Deck deck, BlackJackEngine blackJackEngine)
        {
            string title = IsDealer ? "Dealer draws" : "You draw";

            int playerMove;
            write($"\n{blackJackEngine.ConfirmPlayerStatus(this)}\n");

            while (Score < (IsDealer ? blackJackEngine.MinScore : blackJackEngine.MaxScore))
            {
                if (!IsDealer)
                {
                    playerMove = blackJackEngine.GetPlayerNextMove();
                    if (playerMove != 1)
                    {
                        break;
                    }
                }
                var currentCard = deck.HandOutCard();
                TakeCard(currentCard);
                write($"\n{title} [{currentCard.getDisplayName()}, '{currentCard.Suit}']\n");
                wait();
                UpdateScore(ScoreTracker.CalculateScore(this.Hand));
                write($"\n{blackJackEngine.ConfirmPlayerStatus(this)}\n");

            }
         }

        private void write(string text)
        {
            Console.Write(text);
        }

        protected void wait(int ms = waitTimeInms)
        {
            System.Threading.Thread.Sleep(ms);
        }
    }
}