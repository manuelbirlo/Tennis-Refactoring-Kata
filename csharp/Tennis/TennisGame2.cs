using Tennis.Interfaces;
using Tennis.ScoringStrategies;
using System;

namespace Tennis
{
    /// <summary>
    /// A concrete implementation of a tennis game that keeps track of the score for two players.
    /// </summary>
    public class TennisGame2 : ITennisGame
    {
        // Points for player 1
        private int p1point;
        // Points for player 2
        private int p2point;

        // Names of player 1 and 2
        private string player1Name;
        private string player2Name;

        // A reference to a scoring strategy
        private readonly IScoringStrategy scoringStrategy;

        /// <summary>
        /// Initializes a new instance of the TennisGame2 class with player names and an optional injected scoring strategy.
        /// </summary>
        /// <param name="player1Name">Name of player 1.</param>
        /// <param name="player2Name">Name of player 2.</param>
        /// <param name="scoringStrategy">Optional injected scoring strategy. If no strategy is provided, DefaultScoringStrategy is used.</param>
        public TennisGame2(string player1Name, string player2Name, IScoringStrategy injectedScoringStrategy = null)
        {
            // Validate and set player names
            this.player1Name = string.IsNullOrEmpty(player1Name) ? throw new ArgumentException(nameof(player1Name)) : player1Name;
            this.player2Name = string.IsNullOrEmpty(player2Name) ? throw new ArgumentException(nameof(player2Name)) : player2Name;
            // Initialize the scoring strategy
            scoringStrategy = injectedScoringStrategy ?? new DefaultScoringStrategy();
        }

        /// <summary>
        /// Gets the current score of the game.
        /// </summary>
        /// <returns>A string representing the current score.</returns>
        public string GetScore()
        {
            return scoringStrategy.GetScore(p1point, p2point);
        }

         /// <summary>
        /// Sets the score for player 1.
        /// </summary>
        /// <param name="points">The score to set for player 1.</param>
        public void SetP1Score(int points)
        {
            p1point = points;
        }

        /// <summary>
        /// Sets the score for player 2.
        /// </summary>
        /// <param name="points">The score to set for player 2.</param>
        public void SetP2Score(int points)
        {
            p2point = points;
        }

        /// <summary>
        /// Records a point won by the specified player by updating an internal counter.
        /// </summary>
        /// <param name="player">The name of the player who won the point.</param>
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

