using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Tennis.Interfaces;

namespace Tennis.Tests
{
    /// <summary>
    /// Generates test data for defined tennis game score tests.
    /// </summary>
    public class TestDataGenerator : IEnumerable<object[]>
    {
        /// <summary>
        /// A list of test data representing several tennis game states.
        /// Each object array contains the points of the two players and the expected score.
        /// </summary>
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {0, 0, "Love-All"},
            new object[] {1, 1, "Fifteen-All"},
            new object[] {2, 2, "Thirty-All"},
            new object[] {3, 3, "Deuce"},
            new object[] {4, 4, "Deuce"},
            new object[] {1, 0, "Fifteen-Love"},
            new object[] {0, 1, "Love-Fifteen"},
            new object[] {2, 0, "Thirty-Love"},
            new object[] {0, 2, "Love-Thirty"},
            new object[] {3, 0, "Forty-Love"},
            new object[] {0, 3, "Love-Forty"},
            new object[] {4, 0, "Win for player1"},
            new object[] {0, 4, "Win for player2"},
            new object[] {2, 1, "Thirty-Fifteen"},
            new object[] {1, 2, "Fifteen-Thirty"},
            new object[] {3, 1, "Forty-Fifteen"},
            new object[] {1, 3, "Fifteen-Forty"},
            new object[] {4, 1, "Win for player1"},
            new object[] {1, 4, "Win for player2"},
            new object[] {3, 2, "Forty-Thirty"},
            new object[] {2, 3, "Thirty-Forty"},
            new object[] {4, 2, "Win for player1"},
            new object[] {2, 4, "Win for player2"},
            new object[] {4, 3, "Advantage player1"},
            new object[] {3, 4, "Advantage player2"},
            new object[] {5, 4, "Advantage player1"},
            new object[] {4, 5, "Advantage player2"},
            new object[] {15, 14, "Advantage player1"},
            new object[] {14, 15, "Advantage player2"},
            new object[] {6, 4, "Win for player1"},
            new object[] {4, 6, "Win for player2"},
            new object[] {16, 14, "Win for player1"},
            new object[] {14, 16, "Win for player2"},
            // Additional test cases covering rare scenarios
            // where higher scores are considered 
            // (beyond the scope of a regular tennis game, but theoretically possible):
            new object[] {7, 5, "Win for player1"},
            new object[] {5, 7, "Win for player2"},
            new object[] {8, 6, "Win for player1"},
            new object[] {6, 8, "Win for player2"},
            new object[] {10, 8, "Win for player1"},
            new object[] {8, 10, "Win for player2"},
            new object[] {20, 18, "Win for player1"},
            new object[] {18, 20, "Win for player2"}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TennisTests
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis1Test(int p1, int p2, string expected)
        {
            var game = new TennisGame1("player1", "player2");
            CheckAllScores(game, p1, p2, expected, "player1", "player2");
        }

        /// <summary>
        /// Tests the TennisGame2 implementation using several score combinations and the corresponding expected results.
        /// </summary>
        /// <param name="p1">The number of points for player 1.</param>
        /// <param name="p2">The number of points for player 2.</param>
        /// <param name="expected">The expected score (as a string).</param>
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis2Test(int p1, int p2, string expected)
        {
            // Arrange:
            // Create a new TennisGame2 instance with the two player names "player1" and "player2".
            var game = new TennisGame2("player1", "player2");

            // Act & Assert: 
            // Verify that the game's score matches the expected score for all given points.
            CheckAllScores(game, p1, p2, expected, "player1", "player2");
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis2TestWithDifferentNames(int p1, int p2, string expected)
        {
            // Arrange:
            // Create a new TennisGame2 instance with different player names.
            var game = new TennisGame2("Alice", "Bob");

            // Act & Assert: 
            // Verify that the game's score matches the expected score for all given points.
            CheckAllScores(game, p1, p2, expected, "Alice", "Bob");
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis3Test(int p1, int p2, string expected)
        {
            var game = new TennisGame3("player1", "player2");
            CheckAllScores(game, p1, p2, expected, "player1", "player2");
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis4Test(int p1, int p2, string expected)
        {
            var game = new TennisGame4("player1", "player2");
            CheckAllScores(game, p1, p2, expected, "player1", "player2");
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis5Test(int p1, int p2, string expected)
        {
            var game = new TennisGame5("player1", "player2");
            CheckAllScores(game, p1, p2, expected, "player1", "player2");
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis6Test(int p1, int p2, string expected)
        {
            var game = new TennisGame6("player1", "player2");
            CheckAllScores(game, p1, p2, expected, "player1", "player2");
        }

        /// <summary>
        /// Checks all scores using the given tennis game implementation with the specified scores and expected result.
        /// </summary>
        /// <param name="game">The tennis game implementation to test.</param>
        /// <param name="player1Score">The score for player 1.</param>
        /// <param name="player2Score">The score for player 2.</param>
        /// <param name="expectedScore">The expected score result.</param>
        /// <param name="player1Name">The name of player 1.</param>
        /// <param name="player2Name">The name of player 2.</param>
        private void CheckAllScores(ITennisGame game, int player1Score, int player2Score, string expectedScore, string player1Name, string player2Name)
        {
            // Act
            IncrementPoints(game, player1Name, player1Score);
            IncrementPoints(game, player2Name, player2Score);

            // Assert
            Assert.Equal(expectedScore, game.GetScore());
        }

        /// <summary>
        /// Increments the points for the specified player.
        /// </summary>
        /// <param name="game">The tennis game implementation.</param>
        /// <param name="player">The name of the player to increment points for.</param>
        /// <param name="points">The player's score: The number of points to increment.</param>
        private void IncrementPoints(ITennisGame game, string player, int points)
        {
            for (var i = 0; i < points; i++)
            {
                game.WonPoint(player);
            }
        }
    }
}
