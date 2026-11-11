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

        Move();


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

    protected virtual void Shoot()
    {

        Instantiate(enemyBullet, transform.position, transform.rotation);
    }

    protected virtual void Move()
    {
        transform.position += Vector3.down  * speed *Time.deltaTime;
    }
}
