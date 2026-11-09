using UnityEngine;

public class Base_EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._i.isPaused  || GameManager._i.isEndGame)
        {
            return;
        }

        Vector3 direction = transform.up; // .up la lay huong phia truoc cua object, nó tra ve 1 Vector3
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x > CameraCam.cmr.right || transform.position.x < CameraCam.cmr.left || transform.position.y > CameraCam.cmr.top || transform.position.y < CameraCam.cmr.bottom)
        {
            Destroy(gameObject); // huy 1 object, tham so truyen vao la gameObect luon
        }


        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPlane plane = collision.GetComponent<PlayerPlane>();
        if (plane)
        {
            Destroy(this.gameObject);
            if(plane.IsShieldActive)
            {
                Destroy(gameObject);
                return;
            }
            plane.health -= 1;
            if (plane.health <= 0)
            {
                GameManager._i.PlayerDied();
                Destroy(plane.gameObject);
            }
        }


    }
}
