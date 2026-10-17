using UnityEngine;

public class EnemyBullet3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 10f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 direction = transform.up; // .up la lay huong phia truoc cua object, nó tra ve 1 Vector3
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
        PlayerPlane plane = collision.GetComponent<PlayerPlane>();
        if(plane)
        {
            Destroy(this.gameObject);
            plane.health -=1;
            if(plane.health <= 0)
            {
                Destroy(plane.gameObject);
                
            }
        }
    }
}
