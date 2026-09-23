using UnityEngine;
using UnityEngine.UI;

// Drives the three legacy uGUI Text objects on the HUD canvas.
public class HudController : MonoBehaviour
{
    IScoreKeeper scoreKeeper;

    public Text scoreText;
    public Text livesText;
    public Text gameOverText;

    void Awake()
    {
        //Instance = this;
        gameOverText.gameObject.SetActive(false);
    }

    void Start()
    {
        scoreKeeper = Services.Get<IScoreKeeper>();

        scoreKeeper.ScoreChanged += RefreshScore;
        scoreKeeper.LivesChanged += RefreshLives;
        scoreKeeper.GameOver += ShowGameOver;
        RefreshScore();
        RefreshLives();
    }

    void OnDestroy()
    {
        if (scoreKeeper != null)
        {
            scoreKeeper.ScoreChanged -= RefreshScore;
            scoreKeeper.LivesChanged -= RefreshLives;
            scoreKeeper.GameOver -= ShowGameOver;
        }
    }

    void RefreshScore()
    {
        scoreText.text = $"Score: {scoreKeeper.Score}";
    }

    void RefreshLives()
    {
        livesText.text = $"Lives: {scoreKeeper.Lives}";
    }

    void ShowGameOver()
    {
        gameOverText.text = "GAME OVER\nPress Space to restart";
        gameOverText.gameObject.SetActive(true);
    }
}