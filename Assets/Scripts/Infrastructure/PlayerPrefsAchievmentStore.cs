using UnityEngine;

public class PlayerPrefsAchievmentStore : IAchievementStore
{
    const string Prefix = "Achievment.";

    public bool IsUnlocked(string id)
    {
        return PlayerPrefs.GetInt(Prefix + id, 0) == 1;
    }
    public void Unlock(string id)
    {
        PlayerPrefs.SetInt(Prefix + id, 1);
        PlayerPrefs.Save();
    }
}
