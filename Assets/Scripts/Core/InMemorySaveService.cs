using UnityEngine;

public class InMemorySaveService : ISaveService
{
    int highScore;

    public int LoadHighScore()
    {
        return highScore;
    }

    public void SaveHighScore(int score)
    {
        highScore = score;
    }
}
