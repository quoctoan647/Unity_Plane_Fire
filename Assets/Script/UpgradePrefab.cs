using UnityEngine;

public class UpgradePrefab : MonoBehaviour
{
    private Camera cam;
    private float screenHeight;
    private float screenWidth;
    private float bottom;
    public float speed =3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize*2f;
        screenWidth = cam.aspect*screenHeight;
        bottom = cam.transform.position.y - screenHeight/2f;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.y -=1;
        transform.position += direction*speed*Time.deltaTime;
        if(transform.position.y < bottom)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D  collision)
    {
        PlayerPlane plane = collision.GetComponent<PlayerPlane>();
        if(plane!=null)
        {
            plane.UpgradeBullet();
            Destroy(gameObject);
        }
    }

    
}
