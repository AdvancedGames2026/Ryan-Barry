using System;
using UnityEngine;

public class Achievments : IAchievments
{
    public const string FirstCatch = "First Catch";
    public const string TenInARow = "Ten in a Row";
    public const string TwentyPoints = "Twenty Points";

    readonly IScoreKeeper scoreKeeper;
    readonly IAchievementStore store;
    readonly ILog log;
    int streak;

    public event Action<string> Unlocked;

    public Achievments(IScoreKeeper scoreKeeper, IAchievementStore store, ILog log)
    {
        this.scoreKeeper = scoreKeeper;
        this.store = store;
        this.log = log;

        scoreKeeper.ScoreChanged += OnCatch;
        scoreKeeper.LivesChanged += OnMiss;
    }

    public bool IsUnlocked(string id)
    {
        return store.IsUnlocked(id);
    }
    void OnCatch()
    {
        streak++;

        if (streak >= 1)
        {
            Unlock(FirstCatch);
        }
        if (streak >= 10)
        {
            Unlock(TenInARow);
        }
        if (scoreKeeper.Score >= 20)
        {
            Unlock(TwentyPoints);
        }
    }
    void OnMiss()
    {
        streak = 0;
    }
    void Unlock(string id)
    {
        if (store.IsUnlocked(id))
        {
            return;
        }

        store.Unlock(id);
        log.Log($"Unlocked {id}");
        Unlocked?.Invoke(id);
    }


}
