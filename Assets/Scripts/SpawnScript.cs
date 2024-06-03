using System.Collections;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject flyer;
    [SerializeField] private GameController gameController;
    private float difficulty;

    private Vector3 spawnPosition;
    private float spawnLagTime;
    private float minLag = 1, maxLag = 3;

    private void Awake()
    {
        StartCoroutine(SpawnFlyer());
        difficulty = gameController.Difficulty; //Сложность от 1 до 3
    }

    private IEnumerator SpawnFlyer()
    {
        //Спаун объекта
        spawnPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(-9, 4.5f), transform.position.z);
        Instantiate(flyer, spawnPosition, new Quaternion());

        //Задержка между спаунами сокращается в зависимости от сложности
        minLag = minLag * ((200 - difficulty) / 200);
        maxLag = maxLag * ((200 - difficulty) / 200);

        //Debug.Log(spawnLagTime + "\n" + "min = " + minLag + " max = " + maxLag);

        spawnLagTime = Random.Range(minLag, maxLag);

        yield return new WaitForSeconds(spawnLagTime);
        StartCoroutine(SpawnFlyer());
    }
}