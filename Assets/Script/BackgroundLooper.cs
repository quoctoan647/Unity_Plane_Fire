using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float imageHeight;
    private float bottom;
    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        imageHeight = spriteRenderer.bounds.size.y;
        bottom = cam.transform.position.y - cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y + imageHeight / 2f <= bottom)
        {
            transform.position += Vector3.up * imageHeight * 2f;
        }


    }
}
