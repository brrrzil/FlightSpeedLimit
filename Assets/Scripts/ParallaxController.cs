using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] MeshRenderer meshRenderer;

    private Vector2 meshOffset;

    private void Start()
    {
        meshOffset = meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        meshRenderer.sharedMaterial.mainTextureOffset = meshOffset;
    }

    private void Update()
    {
        var x = Mathf.Repeat(Time.time * speed / 10, 1);
        var offset = new Vector2(x, meshOffset.y);
        meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }

    //[SerializeField] private Transform[] layers;
    //[SerializeField] private float[] coeff;
    //[SerializeField] private float speed;

    //private int layersCount;

    //private void Start()
    //{
    //    layersCount = layers.Length;
    //}

    //private void FixedUpdate()
    //{
    //    MoveEnvironment();
    //}

    //private void MoveEnvironment()
    //{
    //    for (int i = 0; i < layersCount; i++)
    //    {
    //        layers[i].position = new Vector3(layers[i].position.x - coeff[i] * speed / 500, layers[i].position.y, layers[i].position.z);
    //    }
    //}
}