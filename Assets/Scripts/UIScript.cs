using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text SpeedLimitText;

    private GameController gameController;

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        gameController = new GameController();
        SpeedLimitText.text = gameController.SpeedLimit.ToString();        
    }
}