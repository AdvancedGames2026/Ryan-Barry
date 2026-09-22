using UnityEngine;

// Spawns circles on a timer. Both the timer and the fall speed ramp with the score.
public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    public FallingCircle circlePrefab;

    float timer;
    bool running = true;
    float halfWidth;
    float topEdge;

    public float CurrentInterval
    {
        get
        {
            float interval = GameSettings.BaseSpawnInterval - ScoreKeeper.Instance.Score * GameSettings.IntervalPerPoint;
            return Mathf.Max(interval, GameSettings.MinSpawnInterval);
        }
    }

    public float CurrentFallSpeed
    {
        get
        {
            return GameSettings.BaseFallSpeed + ScoreKeeper.Instance.Score * GameSettings.FallSpeedPerPoint;
        }
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
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
}
