

using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    public float speed = 12f;
    public GameObject upgradePrefab;

    public int damage = 1;
    public bool piercing = false;


    void Update()
    {
        Vector3 direction = transform.up;              // .up la lay huong phia truoc cua object, nó tra ve 1 Vector3
        transform.position += direction * speed * Time.deltaTime;



        Camera cam = Camera.main;
        float screenHeight = cam.orthographicSize * 2f;
        float screenWidth = screenHeight * cam.aspect;

        float top = cam.transform.position.y + screenHeight / 2f;
        float bottom = cam.transform.position.y - screenHeight / 2f;
        float left = cam.transform.position.x - screenWidth / 2f;
        float right = cam.transform.position.x + screenWidth / 2f;
        //float y = Mathf.Clamp(transform.position.y, bottom, top);
        //float x = Mathf.Clamp(transform.position.x, left, right);
        //transform.position = new Vector3(x, y, transform.position.z);

        if (transform.position.x > right || transform.position.x < left || transform.position.y > top || transform.position.y < bottom)
        {
            Destroy(gameObject); // huy 1 object, tham so truyen vao la gameObect luon
        }

        if(GameManager._i.isPaused == true)
        {
            return;
        }
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyPlane1 enemy1 = collision.GetComponent<EnemyPlane1>();
        EnemyPlane2 enemy2 = collision.GetComponent<EnemyPlane2>();
        EnemyPlane3 enemy3 = collision.GetComponent<EnemyPlane3>();



        if (enemy1)
        {
            if (piercing == false)
            {
                Destroy(this.gameObject);
            }
            enemy1.health -= damage;
            Debug.Log(enemy1.health);
            if (enemy1.health <= 0)
            {
                Destroy(enemy1.gameObject);

            }
        }

        if (enemy2)
        {
            if (piercing == false)
            {
                Destroy(this.gameObject);
            }
            enemy2.health -= damage;
            Debug.Log(enemy2.health);
            if (enemy2.health <= 0)
            {
                Instantiate(upgradePrefab, enemy2.transform.position, Quaternion.identity);
                Destroy(enemy2.gameObject);


            }
        }

        if (enemy3)
        {
            if (piercing == false)
            {
                Destroy(this.gameObject);
            }
            enemy3.health -= damage;
            Debug.Log(enemy3.health);
            if (enemy3.health <= 0)
            {
                Instantiate(upgradePrefab, enemy3.transform.position, Quaternion.identity);
                Destroy(enemy3.gameObject);

            }

        }
    }
}
