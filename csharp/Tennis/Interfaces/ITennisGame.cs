namespace Tennis.Interfaces
{
    /// <summary>
    /// The interface for a tennis game: 
    /// Defines fundamental methods and properties of a tennis game.
    /// </summary>
    public interface ITennisGame
    {
        /// <summary>
        /// Gets the current score of the tennis match.
        /// </summary>
        /// <returns>A string representing the current score of the game.</returns>
        string GetScore();

        /// <summary>
        /// Records a point won by the specified player.
        /// </summary>
        /// <param name="player">The name of the player who won the point.</param>
        void WonPoint(string player);
    }
}
