using UnityEngine;
using UnityEngine.UI;

// Drives the three legacy uGUI Text objects on the HUD canvas.
public class HudController : MonoBehaviour
{
    public static HudController Instance;

    public Text scoreText;
    public Text livesText;
    public Text gameOverText;

    void Awake()
    {
        Instance = this;
        gameOverText.gameObject.SetActive(false);
    }

    void Start()
    {
        ScoreKeeper keeper = ScoreKeeper.Instance;
        keeper.ScoreChanged += RefreshScore;
        keeper.LivesChanged += RefreshLives;
        keeper.GameOver += ShowGameOver;
        RefreshScore();
        RefreshLives();
    }

    void OnDestroy()
    {
        ScoreKeeper keeper = ScoreKeeper.Instance;
        if (keeper != null)
        {
            keeper.ScoreChanged -= RefreshScore;
            keeper.LivesChanged -= RefreshLives;
            keeper.GameOver -= ShowGameOver;
        }
    }

    void RefreshScore()
    {
        scoreText.text = $"Score: {ScoreKeeper.Instance.Score}";
    }

    void RefreshLives()
    {
        livesText.text = $"Lives: {ScoreKeeper.Instance.Lives}";
    }

    void ShowGameOver()
    {
        gameOverText.text = "GAME OVER\nPress Space to restart";
        gameOverText.gameObject.SetActive(true);
    }
}