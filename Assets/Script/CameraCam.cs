using UnityEngine;

public class CameraCam : MonoBehaviour
{
    public static CameraCam cmr;
    public Camera cam;
    public float screenHeight ;
    public float screenWidth;

    public float left ;
    public float right ;

    public float top ;
    public float bottom ;
    public float x;            //Mathf.Clamp(value, min, max) kiem tra 1 gia tri co nam trong khoan quy dinh ko, neu  ko thi gan lai cho gia tri min hoac max
    public float y;

    public void Awake()
    {
        cmr=this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize * 2f;
        screenWidth = screenHeight * cam.aspect;
        left= cam.transform.position.x - screenWidth / 2f;
        right= cam.transform.position.x + screenWidth / 2f;
        top = cam.transform.position.y + screenHeight / 2f;
        bottom = cam.transform.position.y - screenHeight / 2f;

        x = Mathf.Clamp(transform.position.x, left, right);
        y = Mathf.Clamp(transform.position.y, bottom, top);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
