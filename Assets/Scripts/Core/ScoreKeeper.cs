using System;
using UnityEngine;

// Owns the score and lives. Everything else reads them through ScoreKeeper.Instance.
public class ScoreKeeper : IScoreKeeper
{
    public int Score { get; private set; }
    public int Lives { get; private set; }

    public event Action ScoreChanged;
    public event Action LivesChanged;
    public event Action GameOver;

    public ScoreKeeper()
    {
        Lives = GameSettings.StartingLives;
    }

    public void AddScore()
    {
        if (Lives > 0)
        {
            Score++;
            ScoreChanged?.Invoke();
        }
    }

    public void LoseLife()
    {
        if (Lives > 0)
        {
            Lives--;
            LivesChanged?.Invoke();

            if (Lives == 0)
            {
                GameOver?.Invoke();
            }
        }
    }
}
