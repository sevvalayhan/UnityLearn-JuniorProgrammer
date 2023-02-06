using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions.Must;
using System.Xml.Serialization;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI pauseText;
    public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    public bool gameIsPaused = false;
    public float spawnRate = 0.5f;
    protected int score;
    protected int lives = 3;

    void Update()
    {
        SpawnTarget();
        if (score < 0)
        {
            GameOver();
        }
        livesText.text = "Lives: " + lives;
        PauseGame();


        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGameActive)
            {
                gameIsPaused = !gameIsPaused;

                PauseGame();

            }

        }

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        if (lives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            pauseText.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
        else
        {
            pauseText.gameObject.SetActive(false);

            Time.timeScale = 1;
        }

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        spawnRate /= difficulty;
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }


}
