using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text SpeedLimitText;

    private GameController gameController;

    private void Start()
    {
        gameController = new GameController();
    }

    private void Update()
    {
        SpeedLimitText.text = gameController.SpeedLimit.ToString();
    }
}