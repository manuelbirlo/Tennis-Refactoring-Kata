using Tennis.Interfaces;

namespace Tennis.ScoreHandlers
{
    // A concrete handler for tied scores in the chain of responsibility.
    public class TiedScoreHandler : IScoreHandler
    {
        // A reference to the next score handler in the chain of responsibility.
        private IScoreHandler nextScoreHandler;

        /// <summary>
        /// Sets the next handler in the chain.
        /// </summary>
        /// <param name="nextHandler">The next score handler in the chain of responsibility.</param>
        /// <returns>The next score handler (method chaining).</returns>
        public IScoreHandler SetNext(IScoreHandler nextHandler)
        {
            nextScoreHandler = nextHandler;
            return nextHandler;
        }

        /// <summary>
        /// Handles the scoring in case of a tied score: both players have the same score.
        /// In case the scores are not tied, the responsibility is passed to the next score handler in the chain of responsibility.
        /// </summary>
        /// <param name="pointsPlayerOne">The points of player one.</param>
        /// <param name="pointsPlayerTwo">The points of player two.</param>
        /// <returns>A string representing the score if the scores are tied, otherwise a delegation to the next score handler is triggered.</returns>
        public string Handle(int pointsPlayerOne, int pointsPlayerTwo)
        {
            if (pointsPlayerOne == pointsPlayerTwo)
            {
                switch (pointsPlayerOne)
                {
                    case 0: return "Love-All";
                    case 1: return "Fifteen-All";
                    case 2: return "Thirty-All";
                    default: return "Deuce";
                }
            }

            return nextScoreHandler?.Handle(pointsPlayerOne, pointsPlayerTwo);
        }
    }
}