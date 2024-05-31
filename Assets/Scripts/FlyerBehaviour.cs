using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class FlyerBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TMP_Text text;
    [SerializeField] Sprite[] sprites;

    GameController gameController;

    private float speedLimit;
    private float speed; 
    private Rigidbody rb;
    private bool isIntruder = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Speed() / 10, 0, 0, ForceMode.Impulse);

        int i = Random.Range(0, sprites.Length - 1);
        GetComponent<SpriteRenderer>().sprite = sprites[i];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        rb.useGravity = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        if(isIntruder) { Debug.Log("You caught intruder"); }
        else { Debug.Log("You fake");  }
    }

    private float Speed()
    {
        gameController = new GameController();
        speedLimit = gameController.SpeedLimit;
        Destroy(gameController);

        speed = (float)Random.Range(40, 120);
        text.text = speed.ToString();
        if (speed > speedLimit) isIntruder = true;
        return speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isIntruder)
        {
            gameController = new GameController();
            gameController.Score--;
            Debug.Log("Scores: " + gameController.Score);
            Destroy(gameController);
        }

        else {
            gameController = new GameController();
            gameController.Score++;
            Debug.Log("Scores: " + gameController.Score);
            Destroy(gameController);
        }

        Destroy(gameObject);
    }
}