using UnityEngine;

public class Base_EnemyPlane : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    public float speed = 1f;
    public int health = 4;
    public float timer;
    public Base_EnemyBullet enemyBullet;
    public bool upgrade;


    // Update is called once per frame
    void Update()
    {
        
        if (GameManager._i.isPaused  || GameManager._i.isEndGame)
        {
            return;
        }

        Vector3 direction = Vector3.zero;
        direction.y -= 1;
        transform.position += direction * speed * Time.deltaTime;


        if (transform.position.y < CameraCam.cmr.bottom)
        {
            Destroy(gameObject);
        }



        timer += Time.deltaTime;
        if (timer >= 2)
        {
            Shoot();
            timer = 0;
        }

    }

    void Shoot()
    {

        Instantiate(enemyBullet, transform.position, transform.rotation);
    }
}
