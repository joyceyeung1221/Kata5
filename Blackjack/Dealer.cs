using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Dealer : Player
    {
        public Dealer() : base()
        {

        }

        public void CompleteTurns(Deck deck, BlackJackEngine blackJackEngine)
        {
            write($"\n{blackJackEngine.ConfirmPlayerStatus(this)}\n");
            do
            {
                var currentCard = deck.HandOutCard();
                TakeCard(currentCard);
                write($"Dealer draws [{currentCard.getDisplayName()}, '{currentCard.Suit}']\n");
                wait();
                UpdateScore(ScoreTracker.CalculateScore(this.Hand));
                write($"\n{blackJackEngine.ConfirmPlayerStatus(this)}");
            } while (Score < 17);

        }

    }
}
