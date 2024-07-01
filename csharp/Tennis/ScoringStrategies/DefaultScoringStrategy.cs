using Tennis.Interfaces;
using Tennis.ScoreHandlers;

namespace Tennis.ScoringStrategies
{
    // The implementation of the default scoring strategy of the IScoringStrategy interface
    public class DefaultScoringStrategy : IScoringStrategy
    {
        // Holds a reference to the concrete score first handler in the chain of responsibilities.
        private readonly IScoreHandler chainOfScoreHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultScoringStrategy"/> class.
        /// </summary>
        public DefaultScoringStrategy()
        {
            // The first handler in the chain of responsibilites: The first condition to check is if the scores are tied. 
            chainOfScoreHandlers = new TiedScoreHandler();

            // Chain the remaining handlers in the following order: 1.) Tied, 2.) Advantage, 3.) Win, 4.) DefaultScore;
            chainOfScoreHandlers.SetNext(new AdvantageScoreHandler())
                                .SetNext(new WinScoreHandler())
                                .SetNext(new DefaultScoreHandler());
        }

        // Gets the score based on the points of both players
        public string GetScore(int pointsPlayerOne, int pointsPlayerTwo)
        {
            return chainOfScoreHandlers.Handle(pointsPlayerOne, pointsPlayerTwo);
        }
    }
}

