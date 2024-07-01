namespace Tennis.Interfaces
{
    /// <summary>
    /// The interface for a score handler.
    /// </summary>
    public interface IScoreHandler
    {
        /// <summary>
        /// Sets the next scoring handler in a chain of responsibilities.
        /// </summary>
        /// <param name="nextHandler">Sets the next scoring handler.</param>
        /// <returns>
        /// An instance of the next scoring handler. 
        /// </returns>
        IScoreHandler SetNext(IScoreHandler nextHandler);

        /// <summary>
        /// Handles the logic of the concrete scoring system. 
        /// </summary>
        /// <param name="pointsPlayerOne">The points of player one.</param>
        /// <param name="pointsPlayerTwo">The points of player two.</param>
        /// <returns>
        /// A string representing a chosen specific case in the Tennis scoring system.
        /// <returns>A string representing the score if a specific scoring scenario detected, otherwise a delegation to the next score handler is triggered.</returns>
        string Handle(int pointsPlayerOne, int pointsPlayerTwo);
    }
}

