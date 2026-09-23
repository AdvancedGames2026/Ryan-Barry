using UnityEngine;

// Spawns circles on a timer. Both the timer and the fall speed ramp with the score.
public class Spawner : MonoBehaviour
{
    IScoreKeeper scoreKeeper;

    public FallingCircle circlePrefab;

    float timer;
    bool running = true;
    float halfWidth;
    float topEdge;

    public float CurrentInterval
    {
        get
        {
            float interval = GameSettings.BaseSpawnInterval - scoreKeeper.Score * GameSettings.IntervalPerPoint;
            return Mathf.Max(interval, GameSettings.MinSpawnInterval);
        }
    }

    public float CurrentFallSpeed
    {
        get
        {
            return GameSettings.BaseFallSpeed + scoreKeeper.Score * GameSettings.FallSpeedPerPoint;
        }
    }

    void Awake()
    {
        //Instance = this;
    }

    void Start()
    {

        scoreKeeper = GetComponent<IScoreKeeper>();
        scoreKeeper.GameOver += Stop;

        Camera cam = Camera.main;
        halfWidth = cam.orthographicSize * cam.aspect - 0.5f;
        topEdge = cam.orthographicSize + 1f;
    }

    void Update()
    {
        if (running)
        {
            timer += Time.deltaTime;
            if (timer >= CurrentInterval)
            {
                timer = 0f;
                Vector3 pos = new Vector3(Random.Range(-halfWidth, halfWidth), topEdge, 0f);

                FallingCircle circle = Instantiate(circlePrefab, pos, Quaternion.identity);
                circle.Speed = CurrentFallSpeed;
            }
        }
    }

    public void Stop()
    {
        running = false;
    }

    private void OnDestroy()
    {
        if (scoreKeeper != null)
            scoreKeeper.GameOver -= Stop;
    }

}
