using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject flyer;
    //[SerializeField] Sprite[] sprites;

    private Vector3 spawnPosition;
    private float spawnLagTime;

    private void Start()
    {
        StartCoroutine(SpawnFlyer());
    }

    private IEnumerator SpawnFlyer()
    {
        spawnPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(-10, 5), transform.position.z);
        Instantiate(flyer, spawnPosition, new Quaternion());

        //int i = Random.Range(0, sprites.Length - 1);
        //flyer.GetComponent<SpriteRenderer>().sprite = sprites[i];

        spawnLagTime = Random.Range(0.5f, 2);
        yield return new WaitForSeconds(spawnLagTime);
        StartCoroutine(SpawnFlyer());
    }
}