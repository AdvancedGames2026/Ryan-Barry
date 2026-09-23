using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    IScoreKeeper scoreKeeper;
    IAudioService audioService;

    InputAction moveAction;
    float moveDirection;
    float halfWidth;

    void OnEnable()
    {
        moveAction = InputSystem.actions.FindAction("Player/Move");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
    }

    void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
    }

    void Start()
    {
        scoreKeeper = Services.Get<IScoreKeeper>();
        audioService = Services.Get<IAudioService>();

        Camera cam = Camera.main;
        halfWidth = cam.orthographicSize * cam.aspect - transform.localScale.x * 0.5f;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>().x;
    }

    void Update()
    {
        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x + moveDirection * GameSettings.MoveSpeed * Time.deltaTime, -halfWidth, halfWidth);
        transform.position = p;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out FallingCircle circle))
        {
            scoreKeeper.AddScore();
            audioService.Play(Sound.Catch);
            Destroy(circle.gameObject);
        }
    }
}
