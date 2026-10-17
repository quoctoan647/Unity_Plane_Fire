using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    [SerializeField] private float minSpawnInterval = 3f;
    [SerializeField] private float maxSpawnInterval = 5f;

    private float timer = 0f;
    private float nextSpawnTime;

    private Camera cam;
    private float screenHeight;
    private float screenWidth;
    private float top;
    private float bottom;
    private float left;
    private float right;
    private float randomX;

    void Start()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);

        cam = Camera.main;
        screenHeight = cam.orthographicSize * 2f;
        screenWidth = screenHeight * cam.aspect;

        top = cam.transform.position.y + screenHeight / 2f;
        bottom = cam.transform.position.y - screenHeight / 2f;
        left = cam.transform.position.x - screenWidth / 2f;
        right = cam.transform.position.x + screenWidth / 2f;

        randomX = Random.Range(left + 1, right - 1);

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnRandomEnemy();

            timer = 0f;
            nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            randomX = Random.Range(left + 1, right - 1);
        }
    }

    void SpawnRandomEnemy()
    {

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 position = new Vector3(randomX, top + 1f, 0f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, -180f);

        Instantiate(enemyPrefabs[randomIndex], position, rotation);
    }
}