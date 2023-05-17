using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI ballText;
    [SerializeField] TextMeshProUGUI highScoreText;
    public GameObject titleScreen;
    public GameObject countScreen;
    public GameObject controlsScreen;
    public GameObject gameOverScreen;

    public int score = 0;
    public int balls = 10;

    public int highScore;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        highScore =  PlayerPrefs.GetInt("highscore");
        highScoreText.text = "High Score: " + highScore;
    }

    // Add to the score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Track number of balls remaining
    public void UpdateBalls()
    {
        balls--;
        ballText.text = "Balls: " + balls;

        // Stop the game when the player runs out of balls
        if (balls == 0)
        {
            // Use a coroutine to wait a few seconds for the balls to go into zones
            StartCoroutine(GameOver(6));
        }
    }

    public IEnumerator GameOver(float timeToWait)
    {
        // Wait a few seconds
        yield return new WaitForSeconds(timeToWait);

        // Update the high score
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + highScore;
        }

        // Turn on the game over and restart menu
        gameOverScreen.gameObject.SetActive(true);

        // Set to game over so other scripts know to stop
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        
        // Reset the values if there was a previous game
        score = 0;
        scoreText.text = "Score: " + score;
        balls = 10;
        ballText.text = "Balls: " + balls;

        // Turn off the title menu
        titleScreen.gameObject.SetActive(false);
    }

    public void OpenControls()
    {
        // Turn off the title menu and turn on the controls menu
        titleScreen.gameObject.SetActive(false);
        countScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(true);
    }

    public void CloseControls()
    {
        // Turn on the title menu and turn off the controls menu
        controlsScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        countScreen.gameObject.SetActive(true);
    }
}
