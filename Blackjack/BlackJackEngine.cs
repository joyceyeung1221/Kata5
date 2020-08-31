using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class BlackJackEngine
    {
        private Player _player;
        private Player _dealer;
        private Deck _deck;
        private const int _numberOfStartingCards = 2;
        private const int maxScore = 21;
        private const int minScore = 17;
        private const int waitTimeInms = 2000;
        public int MaxScore => maxScore;
        public int MinScore => minScore;


        public BlackJackEngine()
        {
            _player = new Player();
            _dealer = new Player(isDealer: true);
            _deck = new Deck();
        }

        public void StartGame()
        {
            write("*** Start Dealing ***\n");

            wait();

            this.handleStartingHands();

            _player.CompleteTurns(_deck, this);

            if (_player.Score <= maxScore)
            {
                _dealer.CompleteTurns(_deck, this);
            }

            write(announceWinner(ScoreTracker.FindWinner(_player, _dealer)));

            wait();
        }

        private void handleStartingHands()
        {
            for (int i = 1; i <= _numberOfStartingCards; i++)
            {
                _player.TakeCard(_deck.HandOutCard());

                _dealer.TakeCard(_deck.HandOutCard());
            }

            _player.UpdateScore(ScoreTracker.CalculateScore(_player.Hand));

            _dealer.UpdateScore(ScoreTracker.CalculateScore(_dealer.Hand));
        }

        public string ConfirmPlayerStatus(Player player)
        {
            string title = player.IsDealer ? "Dealer is" : "You are";

            var listOfCards = new List<string>();

            foreach (Card card in player.Hand)
            {
                listOfCards.Add($"[{card.getDisplayName()}, '{card.Suit}']");
            }

            var handInDisplayFormat = String.Join(", ", listOfCards);

            string playerScore = player.Score > 21 ? "a Bust!" : player.Score.ToString();

            return $"{title} currently at {playerScore}\nwith the hand [{handInDisplayFormat}]\n";
        }

        public int GetPlayerNextMove()
        {
            int? userInput;
            bool isNumber;
            do
            {
                isNumber = true;
                userInput = null;

                write("Hit or stay? (Hit = 1, Stay = 0) ");

                isNumber = Int32.TryParse(Console.ReadLine(), out int input);

                userInput = input;

            } while (!isNumber || userInput > 1 || userInput < 0);

            return userInput.GetValueOrDefault();
        }

        private string announceWinner(Player winner)
        {
            if (winner == _player)
            {
                return "\nYou beat the dealer!\n";
            }
            else if (winner == _dealer)
            {
                return "\nDealer wins!\n";
            }
            else { return "\nIts a draw!\n"; }
        }

        private void write(string text)
        {
            Console.Write(text);
        }

        private void wait(int ms = waitTimeInms)
        {
            System.Threading.Thread.Sleep(ms);
        }
    }

}
