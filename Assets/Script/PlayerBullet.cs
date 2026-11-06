

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

         if (GameManager._i.isPaused || GameManager._i.isEndGame)
        {
            return;
        }

        Vector3 direction = transform.up;              // .up la lay huong phia truoc cua object, nó tra ve 1 Vector3
        transform.position += direction * speed * Time.deltaTime;



        
        //float y = Mathf.Clamp(transform.position.y, bottom, top);
        //float x = Mathf.Clamp(transform.position.x, left, right);
        //transform.position = new Vector3(x, y, transform.position.z);

        if (transform.position.x > CameraCam.cmr.right || transform.position.x < CameraCam.cmr.left || transform.position.y > CameraCam.cmr.top || transform.position.y < CameraCam.cmr.bottom)
        {
            Destroy(gameObject); // huy 1 object, tham so truyen vao la gameObect luon
        }

       
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        Base_EnemyPlane enemy = collision.GetComponent<Base_EnemyPlane>();

        if (enemy)
        {
            
            if (piercing == false)
            {
                
                Destroy(this.gameObject);
            }
            enemy.health -= damage;
            Debug.Log(enemy.health);
            if (enemy.health <= 0)
            {
                GameManager._i.EnemyKilled();
                if(enemy.upgrade)
                {
                    Instantiate(upgradePrefab,enemy.transform.position,enemy.transform.rotation);
                }
                Destroy(enemy.gameObject);
            }
        }

    }
}
