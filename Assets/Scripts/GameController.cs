using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public float speed = 2f;

    public Text scoreText;
    public Text highScoreText;
    public GameObject gameoverPanel;

    int score = 0;

    public bool gameover { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameover = false;
        gameoverPanel.SetActive(false);

        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void Die()
    {
        gameover = true;
        gameoverPanel.SetActive(true);

        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
    }
}
