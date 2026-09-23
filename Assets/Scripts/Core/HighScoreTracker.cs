using UnityEngine;

public class HighScoreTracker
{
    IScoreKeeper scoreKeeper;
    ISaveService save;

    public int Best { get; private set; }

    public HighScoreTracker(IScoreKeeper scoreKeeper, ISaveService save)
    {
        this.scoreKeeper = scoreKeeper;
        this.save = save;

        Best = save.LoadHighScore();
        scoreKeeper.GameOver += OnGameOver;


    }

    void OnGameOver()
    {
        if (scoreKeeper.Score > Best)
        {
            Best = scoreKeeper.Score;
            save.SaveHighScore(Best);
        }
    }
}
