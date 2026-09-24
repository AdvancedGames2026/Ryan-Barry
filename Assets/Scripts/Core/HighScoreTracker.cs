using UnityEngine;

public class HighScoreTracker : IHighScore
{
    IScoreKeeper scoreKeeper;
    ISaveService save;
    ILog logger;

    public int Best { get; private set; }

    public HighScoreTracker(IScoreKeeper scoreKeeper, ISaveService save, ILog logger)
    {
        this.scoreKeeper = scoreKeeper;
        this.save = save;
        this.logger = logger;

        Best = save.LoadHighScore();
        scoreKeeper.GameOver += OnGameOver;
    }

    void OnGameOver()
    {
        if (scoreKeeper.Score > Best)
        {
            Best = scoreKeeper.Score;
            save.SaveHighScore(Best);
            logger.Log($"New high score: {Best}");
        }
    }
}
