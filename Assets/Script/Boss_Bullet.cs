using UnityEngine;

public class Boss_Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;
    [SerializeField] private bool isUnti = false;
    [SerializeField] private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (GameManager._i.isPaused || GameManager._i.isEndGame)
        {
            return;
        }

        if (isUnti)
        {
            transform.localPosition = new Vector3(0, 2f, 0);
            if (timer >= 2.5f)
            {
                Destroy(gameObject);
                timer = 0f;
            }
        }
        else
        {
            transform.position += transform.up * speed * Time.deltaTime;
            if (transform.position.x > CameraCam.cmr.right || transform.position.x < CameraCam.cmr.left || transform.position.y > CameraCam.cmr.top || transform.position.y < CameraCam.cmr.bottom)
            {
                Destroy(gameObject); // huy 1 object, tham so truyen vao la gameObect luon
            }

        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPlane plane = collision.GetComponent<PlayerPlane>();
        if (plane)
        {
            if (!isUnti)
            {
                Destroy(this.gameObject);
            }
            plane.health -= damage;
            if (plane.health <= 0)
            {
                GameManager._i.PlayerDied();
                Destroy(plane.gameObject);
            }
        }
    }
}
