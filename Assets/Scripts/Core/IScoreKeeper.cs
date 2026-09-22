using System;
using UnityEngine;

public interface IScoreKeeper
{
    event Action ScoreChanged;
    event Action LivesChanged;
    event Action GameOver;

    int Score { get; }  
    int Lives { get; }

    void AddScore();
    void LoseLife();
}
