using UnityEngine;

public class FallingCircle : MonoBehaviour
{
    public float Speed = 3f; // set by Spawner when instantiated

    IScoreKeeper scoreKeeper;
    IAudioService audioService;

    Rigidbody2D body;
    float bottomEdge;

    void Start()
    {
        scoreKeeper = Services.Get<IScoreKeeper>();
        audioService = Services.Get<IAudioService>();

        body = GetComponent<Rigidbody2D>();
        bottomEdge = -Camera.main.orthographicSize - transform.localScale.y;
    }

    void Update()
    {
        
        body.linearVelocity = Vector2.down * Speed;

        if (transform.position.y <= bottomEdge)
        {
            scoreKeeper.LoseLife();
            audioService.Play(Sound.LoseLife);
            Destroy(gameObject);
        }
    }
}
