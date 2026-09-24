using UnityEngine;
using System.Collections.Generic;

public class InMemoryAchievmentStore : IAchievementStore
{
    readonly HashSet<string> unlocked = new HashSet<string>();

    public bool IsUnlocked(string id) => unlocked.Contains(id);
    public void Unlock(string id) => unlocked.Add(id);
}
