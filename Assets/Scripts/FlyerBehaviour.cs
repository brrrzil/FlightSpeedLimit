using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class FlyerBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TMP_Text text;
    [SerializeField] Sprite[] sprites;
    [SerializeField] private float minStartSpeed, maxStartSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text getScoreText;

    GameController gameController;
    AudioSource audioSource;

    private static float speedIncrease;
    public float SpeedIncrease { get { return speedIncrease; } set { speedIncrease = value; } }

    private float speedLimit;
    private float speed; 
    private Rigidbody rb;
    private bool isIntruder = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        rb.AddForce(Speed() / 10, 0, 0, ForceMode.Impulse);

        int i = Random.Range(0, sprites.Length - 1);
        GetComponent<SpriteRenderer>().sprite = sprites[i];

        speedIncrease += 1;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();

        rb.useGravity = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        if (isIntruder)
        {
            gameController.Score++;
            animator.gameObject.SetActive(true);
            getScoreText.text = "<color=green>+1</color>";
        }

        else
        {
            gameController.Score--;
            animator.gameObject.SetActive(true);
            getScoreText.text = "<color=red>-1</color>";
        }
    }

    private float Speed()
    {
        gameController = new GameController();
        speedLimit = gameController.SpeedLimit;
        Destroy(gameController);

        speed = (float)Random.Range(minStartSpeed + speedIncrease, maxStartSpeed + speedIncrease);
        text.text = ((int)speed).ToString();
        if ((int)speed > (int)speedLimit) isIntruder = true;

        return speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isIntruder)
        {
            gameController = new GameController();
            gameController.Lives--;
            Destroy(gameController);
        }

        else {
            gameController = new GameController();
            gameController.Score++;
            Destroy(gameController);
        }

        Destroy(gameObject);
    }
}