using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private float SetSpeedLimit;
    [SerializeField, Range(1, 3)] private int difficulty;
    [SerializeField] private int setLives;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text yourScoresText, highScoresText;

    private bool isGameOver;

    private static int highScores;
    public int HighScores { get { return highScores; } set { highScores = value; } }

    private static float speedLimit;
    public float SpeedLimit { get { return speedLimit; } set { speedLimit = value; } }

    public int Difficulty { get { return difficulty; } set { difficulty = value; } }

    private static int scores;
    public int Score { get { return scores; } set { scores = value; } }
    [SerializeField] TMP_Text scoreText;

    private static int lives;
    public int Lives { get { return lives; } set { lives = value; } }
    [SerializeField] TMP_Text livesText;

    [SerializeField] private FlyerBehaviour flyerBehaviour;

    void Start()
    {
        flyerBehaviour.SpeedIncrease = 0;
        isGameOver = false;
        SpeedLimit = SetSpeedLimit;
        scores = 0;
        lives = setLives;
    }

    void Update()
    {
        if (scores <= 0) scores = 0;
        scoreText.text = scores.ToString();

        livesText.text = string.Empty;
        for (int i = 0; i < lives; i++)
        {
            livesText.text += "*";
        }

        if ((lives <= 0) && !isGameOver) GameOver();
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        if (scores > highScores) highScores = scores;
        yourScoresText.text = scores.ToString();
        highScoresText.text = highScores.ToString();
        audioSource.Stop();
    }
}