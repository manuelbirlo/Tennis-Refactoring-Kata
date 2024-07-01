namespace Tennis.Interfaces
{
    /// <summary>
    /// The interface for a scoring strategy
    /// </summary>
    public interface IScoringStrategy
    {
        /// <summary>
        /// Gets the current score of the tennis match with a specific underlying scoring method.
        /// </summary>
        /// <param name="pointsPlayerOne">The points of player 1.</param>
        /// <param name="pointsPlayerTwo">The points of player 2.</param>
        /// <returns>
        /// A string representing the current score of the game, 
        /// retreived by a a specific underlying scoring method.
        /// </returns>
        string GetScore(int pointsPlayerOne, int pointsPlayerTwo);
    }
}


