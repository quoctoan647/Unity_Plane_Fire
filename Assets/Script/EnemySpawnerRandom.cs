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
        if (GameManager._i.isPaused || GameManager._i.isEndGame)
        {
            return;
        }

        timer += Time.deltaTime;

        if (GameManager._i.enemiesKilled == 15 && GameManager._i.lastStage == 15)
        {
            Vector3 position = new Vector3(0, CameraCam.cmr.top - 2f, 0);
            Quaternion rotation = Quaternion.Euler(0f, 0f, -180f);
            Instantiate(enemyPrefabs[3], position, rotation);
            GameManager._i.lastStage = 16;
            return;
        }

        if (GameManager._i.lastStage > 15) return;

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

        int randomIndex = Random.Range(0, enemyPrefabs.Length - 1);
        Vector3 position = new Vector3(randomX, CameraCam.cmr.top + 1f, 0f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, -180f);

        Instantiate(enemyPrefabs[randomIndex], position, rotation);
    }
}