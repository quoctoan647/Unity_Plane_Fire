using UnityEngine;

public class EnemyPlane1 : MonoBehaviour
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
        screenWidth = screenHeight * cam.aspect;

        top = cam.transform.position.y + screenHeight / 2f;
        bottom = cam.transform.position.y - screenHeight / 2f;
        left = cam.transform.position.x - screenWidth / 2f;
        right = cam.transform.position.x + screenWidth / 2f;


    }

    // Update is called once per frame
    public float speed = 1f;
    public int health = 4;


    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.y -= 1;
        transform.position += direction * speed * Time.deltaTime;


        if (transform.position.y < bottom)
        {
            Destroy(gameObject);
        }

        
        if(GameManager._i.isPaused == true)
        {
            return;
        }

    }


}
