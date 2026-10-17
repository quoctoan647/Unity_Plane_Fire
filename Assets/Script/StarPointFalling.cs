using UnityEngine;

public class StarPointFalling : MonoBehaviour
{
    private Camera cam;
    private float screenHeight;
    private float screenWidth;
    private float top;
    private float bottom;
    private float left;
    private float right;
    private float randomX;
    private float minTime = 4f;
    private float maxTime = 6f;
    private float spawnTime;
    private float timer = 0f;
    [SerializeField] private StarPoint sp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize * 2f;
        screenWidth = screenHeight * cam.aspect;

        top = cam.transform.position.y + screenHeight / 2f;
        bottom = cam.transform.position.y - screenHeight / 2f;
        left = cam.transform.position.x - screenWidth / 2f;
        right = cam.transform.position.x + screenWidth / 2f;

        randomX = Random.Range(left + 1, right - 1);
        spawnTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            Create();
            timer = 0f;
            randomX = Random.Range(left + 1, right - 1);
            spawnTime = Random.Range(minTime, maxTime);
        }
    }


    void Create()
    {
        Vector3 position = new Vector3(randomX, top + 1, 0);

        Instantiate(sp, position, Quaternion.identity);
    }
}
