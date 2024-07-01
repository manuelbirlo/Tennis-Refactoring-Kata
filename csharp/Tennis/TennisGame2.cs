using Tennis.Interfaces;
using Tennis.ScoringStrategies;
using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string player1Name;
        private string player2Name;

        // Holds a reference to a scoring strategy
        private readonly IScoringStrategy scoringStrategy;

        public TennisGame2(string player1Name, string player2Name, IScoringStrategy injectedScoringStrategy = null)
        {
            this.player1Name = string.IsNullOrEmpty(player1Name) ? throw new ArgumentException(nameof(player1Name)) : player1Name;
            this.player2Name = string.IsNullOrEmpty(player2Name) ? throw new ArgumentException(nameof(player2Name)) : player2Name;
            scoringStrategy = injectedScoringStrategy ?? new DefaultScoringStrategy();
        }

        public string GetScore()
        {
            return scoringStrategy.GetScore(p1point, p2point);
        }

        public void SetP1Score(int points)
        {
            p1point = points;
        }

        public void SetP2Score(int points)
        {
            p2point = points;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                p1point++;
            else if (player == "player2")
                p2point++;
            else
                throw new ArgumentException("Invalid player name", nameof(player));
        }
    }
}

