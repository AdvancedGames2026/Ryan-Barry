using UnityEngine;

public class UnityLog : ILog
{
    public void Log(string message)
    {
        Debug.Log(message);
    }
    public void Warn(string message)
    {
        Debug.LogWarning(message);
    }
}
