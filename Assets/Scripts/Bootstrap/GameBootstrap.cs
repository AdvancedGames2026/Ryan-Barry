using UnityEngine;
using System.IO;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] AudioService audioService;

    void Awake()
    {
        IScoreKeeper scoreKeeper = new ScoreKeeper();
        //ISaveService saveService = new InMemorySaveService();
        FileSaveService saveService = new FileSaveService(Path.Combine(Application.persistentDataPath, "save.json"));
        ILog logger = new UnityLog();
        //ILog logger = new NullLog();

        Services.Clear();
        Services.Register<IScoreKeeper>(scoreKeeper);
        Services.Register<IAudioService>(audioService);
        Services.Register<ISaveService>(saveService);

        IHighScore highScore = new HighScoreTracker(scoreKeeper, saveService, logger);
        Services.Register<IHighScore>(highScore);
        Services.Register<IRandom>(new SystemRandom());

        IAchievments achievments = new Achievments(scoreKeeper, new PlayerPrefsAchievmentStore(), logger);

        Services.Register<IAchievments>(achievments);
        //Debug.Log(Application.persistentDataPath);
    }
}
