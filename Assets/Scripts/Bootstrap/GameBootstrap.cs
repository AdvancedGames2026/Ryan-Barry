using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    void Awake()
    {
        Services.Clear();
        Services.Register<IScoreKeeper>(new ScoreKeeper());
    }
}
