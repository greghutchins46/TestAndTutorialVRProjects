using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;
    private float sliderCurrentFillAmount = 1f;
    private int playerScore;
    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [Header("Game Over Components")]
    [SerializeField] private GameObject gameOverScreen;
    [Header("High Score Components")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;
    public enum GameState
    {
        Waiting,
        Playing,
        GameOver
    }
    // People definitely have opinions about static
    public static GameState currentGameStatus;
    private void Awake()
    {
        currentGameStatus = GameState.Waiting;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
    private void Update()
    {
        if (currentGameStatus == GameState.Playing)
        {
            AdjustTimer();
        }
    }
    private void AdjustTimer () {
        timerImage.fillAmount = sliderCurrentFillAmount - (Time.deltaTime / gameTime);
        sliderCurrentFillAmount = timerImage.fillAmount;

        if (sliderCurrentFillAmount <= 0f)
        {
            GameOver();
        }
    }

    public void UpdatePlayerScore (int asteroidHitPoints)
    {
        if (currentGameStatus != GameState.Playing)
            return;

        playerScore += asteroidHitPoints;
        scoreText.text = playerScore.ToString();
    }
    public void StartGame()
    {
        currentGameStatus = GameState.Playing;
    }
    public void GameOver()
    {
        currentGameStatus = GameState.GameOver;

        // Show the game over screen
        gameOverScreen.SetActive(true);

        // Check the high score...
        if (playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = playerScore.ToString();
        }
    }
    public void ResetGame()
    {
        currentGameStatus = GameState.Waiting;
        // put timer to 1
        sliderCurrentFillAmount = 1f;
        timerImage.fillAmount = 1f;
        // reset the score
        playerScore = 0;
        scoreText.text = "0";
    }
}
