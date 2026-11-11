using UnityEngine;

public class Boss_plane : Base_EnemyPlane
{
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;
    [SerializeField] private float direction = -1f;
    [SerializeField] private Boss_Bullet bullet;
    [SerializeField] private Boss_Bullet Unti;

    [SerializeField] private int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftBorder = CameraCam.cmr.left + 3;
        rightBorder = CameraCam.cmr.right - 3;
        speed = 2f;

    }


    protected override void Move()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
        if (transform.position.x <= leftBorder)
        {
            direction = 1f;
        }
        else if (transform.position.x >= rightBorder)
        {
            direction = -1f;
        }


    }

    protected override void Shoot()
    {
        if (count == 3)
        {
            Instantiate(Unti, transform);
            count = 0;
            return;
        }
        Instantiate(bullet, transform.position, transform.rotation);
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 135f));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, -135f));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90f));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, -90f));
        count++;
    }
}
