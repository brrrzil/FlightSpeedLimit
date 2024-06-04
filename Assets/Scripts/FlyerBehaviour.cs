using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

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
        gameObject.GetComponent<CapsuleCollider>().enabled = false; // Отключаем коллайдер, чтобы не было столкновения с финишем

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

        speed = Random.Range(minStartSpeed + speedIncrease, maxStartSpeed + speedIncrease); // Скорость увеличивается с появлением каждого летуна
        text.text = ((int)speed).ToString();
        if ((int)speed > (int)speedLimit) isIntruder = true;

        return speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameController = new GameController();

        if (isIntruder)
        {
            gameController.Lives--;
        }

        else
        {
            gameController.Score++;
        }
        
        Destroy(gameController);
        Destroy(gameObject);
    }
}