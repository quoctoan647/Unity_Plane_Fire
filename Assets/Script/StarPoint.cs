using UnityEngine;

public class StarPoint : MonoBehaviour
{
    private Camera cam;
    private float screenHeight;
    private float screenWidth;
    private float top;
    private float bottom;
    private float left;
    private float right;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize * 2f;
        screenWidth = screenHeight * cam.aspect;

        top = cam.transform.position.y + screenHeight / 2f;
        bottom = cam.transform.position.y - screenHeight / 2f;
        left = cam.transform.position.x - screenWidth / 2f;
        right = cam.transform.position.x + screenWidth / 2f;cam = Camera.main;
        screenHeight = cam.orthographicSize * 2f;
        screenWidth = screenHeight * cam.aspect;

        top = cam.transform.position.y + screenHeight / 2f;
        bottom = cam.transform.position.y - screenHeight / 2f;
        left = cam.transform.position.x - screenWidth / 2f;
        right = cam.transform.position.x + screenWidth / 2f;
    }

    private float speed=3f;
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.y -=1;
        transform.position +=direction*speed*Time.deltaTime;
        
        if(transform.position.y < bottom)
        {
            Destroy(this.gameObject);
        }
        
        if(GameManager._i.isPaused == true)
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPlane plane = collision.GetComponent<PlayerPlane>();
        if(plane != null)
        {
            plane.point++;
            Debug.Log("Điểm của người chơi là: " + plane.point);
            Destroy(this.gameObject);
        }
        
    }
}
