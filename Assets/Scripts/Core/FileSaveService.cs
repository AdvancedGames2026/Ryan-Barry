using UnityEngine;
using System.IO;

public class FileSaveService : ISaveService
{
    string path;

    public FileSaveService(string path)
    {
        this.path = path;
    }

    public int LoadHighScore()
    {
        if (File.Exists(path))
        {
            if (int.TryParse(File.ReadAllText(path), out int score))
                return score;
        }
        return 0;
    }
    public void SaveHighScore(int score)
    {
        File.WriteAllText(path, score.ToString());
    }
    
}
