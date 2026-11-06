using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    [SerializeField] private float minSpawnInterval = 3f;
    [SerializeField] private float maxSpawnInterval = 5f;

    private float timer = 0f;
    private float nextSpawnTime;

    private float randomX;

    void Start()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);


        randomX = Random.Range(CameraCam.cmr.left + 1, CameraCam.cmr.right - 1);

    }

    void Update()
    {
        if (GameManager._i.isPaused  || GameManager._i.isEndGame)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnRandomEnemy();

            timer = 0f;
            nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            randomX = Random.Range(CameraCam.cmr.left + 1, CameraCam.cmr.right - 1);
        }
    }

    void SpawnRandomEnemy()
    {

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 position = new Vector3(randomX, CameraCam.cmr.top + 1f, 0f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, -180f);

        Instantiate(enemyPrefabs[randomIndex], position, rotation);
    }
}