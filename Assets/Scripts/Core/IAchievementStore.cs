using UnityEngine;

public interface IAchievementStore
{
    bool IsUnlocked(string id);
    void Unlock(string id);
}
