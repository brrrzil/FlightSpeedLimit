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
}