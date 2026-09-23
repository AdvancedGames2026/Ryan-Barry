using UnityEngine;

public class PlayerPrefsSaveService : ISaveService
{
    const string Key = "HighScore";

    public int LoadHighScore()
    {
        return PlayerPrefs.GetInt(Key, 0);
    }

    public void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt(Key, score);
        PlayerPrefs.Save();
    }
    
}
