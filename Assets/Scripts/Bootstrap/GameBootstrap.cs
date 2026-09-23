using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] AudioService audioService;

    void Awake()
    {
        Services.Clear();
        Services.Register<IScoreKeeper>(new ScoreKeeper());
        Services.Register<IAudioService>(audioService);
    }
}
