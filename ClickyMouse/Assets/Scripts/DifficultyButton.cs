using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;
    public int difficulty;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDificculty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (button.gameObject.tag.Equals("Bad"))
        {
            gameManager.GameOver();
        }
    }

    void Update()
    {        
    }

    private void SetDificculty()
    {
        gameManager.StartGame(difficulty);
        Debug.Log(button.gameObject.name + " was clicked");

    }
}
