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
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    public float spawnRate = 0.5f;
    protected int score;

    void Update()
    {
        SpawnTarget();
        if (score<0)
        {
            GameOver();
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

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
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
