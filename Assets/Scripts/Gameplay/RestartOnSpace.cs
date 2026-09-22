using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Once the game is over, the Restart action (Space / gamepad Start) reloads the scene.
public class RestartOnSpace : MonoBehaviour
{
    InputAction restartAction;

    void OnEnable()
    {
        restartAction = InputSystem.actions.FindAction("Player/Restart");
        restartAction.performed += OnRestart;
    }

    void OnDisable()
    {
        restartAction.performed -= OnRestart;
    }

    void OnRestart(InputAction.CallbackContext context)
    {
        if (ScoreKeeper.Instance.Lives <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
