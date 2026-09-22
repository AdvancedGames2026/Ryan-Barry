using UnityEngine;

public class FallingCircle : MonoBehaviour
{
    public float Speed = 3f; // set by Spawner when instantiated

    Rigidbody2D body;
    float bottomEdge;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        bottomEdge = -Camera.main.orthographicSize - transform.localScale.y;
    }

    void Update()
    {
        
        body.linearVelocity = Vector2.down * Speed;

        if (transform.position.y <= bottomEdge)
        {
            ScoreKeeper.Instance.LoseLife();
            Destroy(gameObject);
        }
    }
}
