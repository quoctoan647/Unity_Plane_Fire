using UnityEngine;

public class EnemyPlane3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera cam;
    private float screenHeight;
    private float screenWidth;
    private float top;
    private float bottom;
    private float left;
    private float right;

    void Start()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize * 2f;
        screenWidth = cam.aspect * screenHeight;

        top = cam.transform.position.y + screenHeight / 2f;
        bottom = cam.transform.position.y - screenHeight / 2f;
        left = cam.transform.position.x - screenWidth / 2f;
        right = cam.transform.position.x + screenWidth / 2f;





    }

    public int health = 3;
    public float speed = 1f;
    public float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.y -= 1;
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.y < bottom)
        {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
        Shoot();

    }

    public EnemyBullet3 bullet3;
    void Shoot()
    {

        if (timer >= 1.5)
        {
            timer = 0f;
            Instantiate(bullet3, transform.position, transform.rotation);

        }
    }
}
