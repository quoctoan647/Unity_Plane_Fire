using UnityEngine;

public class StarPoint : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private float speed=3f;
    // Update is called once per frame
    void Update()
    {

         if(GameManager._i.isPaused || GameManager._i.isEndGame)
        {
            return;
        }

        Vector3 direction = Vector3.zero;
        direction.y -=1;
        transform.position +=direction*speed*Time.deltaTime;
        
        if(transform.position.y < CameraCam.cmr.bottom)
        {
            Destroy(this.gameObject);
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
