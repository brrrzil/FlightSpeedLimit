using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static float speedLimit;
    [SerializeField] private float SetSpeedLimit;
    public float SpeedLimit { get { return speedLimit; } set { speedLimit = value; } }

    private static int scores;
    public int Score { get { return scores; } set { scores = value; } }

    void Awake()
    {
        SpeedLimit = SetSpeedLimit;
        scores = 0;
    }

    void Update()
    {
        
    }
}