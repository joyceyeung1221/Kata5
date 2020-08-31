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
                playerScore += playerScore > 10 ? 1 : 11;
            }
            return playerScore;
        }

        public static Player FindWinner(Player player, Player dealer)
        {
            if (player.Score > 21 || (dealer.Score > player.Score && dealer.Score < 21))
            {
                return dealer;
            }
            else if (player.Score > dealer.Score || dealer.Score > 21)
            {
                return player;
            }
            else { return null; }
        }
    }
}
