using UnityEngine;
using System;

public interface IAchievments
{
    event Action<string> Unlocked;
    bool IsUnlocked(string id);
}
