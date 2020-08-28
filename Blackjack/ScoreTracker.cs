using System;
using System.Collections.Generic;

namespace Blackjack
{
    public static class ScoreTracker
    {
        public static int CalculateScore(List<Card> hand)
        {

            int playerScore = 0;
            int numberOfAce = 0;
            foreach (Card card in hand)
            {
                playerScore += card.Value;
                if (card.Value == 0)
                {
                    numberOfAce++;
                }
            }
            if (numberOfAce > 1)
            {
                playerScore += numberOfAce - 1;
            }
            if (numberOfAce > 0)
            {
                playerScore += (playerScore > 11 ? 1 : 11);
            }
            return playerScore;
        }
    }
}
