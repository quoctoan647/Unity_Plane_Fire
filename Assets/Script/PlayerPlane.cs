
using UnityEngine;

public class PlayerPlane : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, -3, 0);  // c# ko cho phep viet lenh thuc thi bên ngoài method, nen bat buoc phai viet ben trong 1 method nao do

        GameManager._i.BeginGame();
    }

    // Update is called once per frame
    public float speed = 8f;
    public float acceleration = 2f;
    public PlayerBullet bulletPrefab;
    public PlayerBullet bulletLevel2;
    public PlayerBullet bulletLevel3;
    public int bulletLevel = 1;
    public float timer = 0f;
    public int health = 10;
    public int point = 0;


    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction.y += 1;

        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction.y -= 1;

        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x += 1;

        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x -= 1;

        }


        // Reset speed ve 8 khi object dung
        if (direction != Vector3.zero)
        {
            speed += acceleration * Time.deltaTime;
            // float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;  //Mathf.Atan2 la tinh goc di chuyen so voi truc ngang(tuc la Ox) bằng cách xac dinh tham so dau la truc dung va tham so thu 2 la truc ngang ne khi truyen tham so vao thi phai de y truoc x sau, con Mathf.Rad2Deg la doi so ve don vi do
            // transform.rotation = Quaternion.Euler(0, 0, rot);                          // ngoài ra, do  unity quy uoc truc duong Ox (tuc goc 0 do) la truc bat dau, ma sprite cua minh mac dinh quay dau len tren (tuc la goc 90 do) nen khi tính huong quay phai  - 90f de bu
        }
        else
        {
            speed = 8f;
        }

        transform.position += direction * (speed * Time.deltaTime);

        Camera cam = Camera.main;
        float screenHeight = cam.orthographicSize * 2f;
        float screenWidth = screenHeight * cam.aspect;

        float left = cam.transform.position.x - screenWidth / 2f;
        float right = cam.transform.position.x + screenWidth / 2f;

        float top = cam.transform.position.y + screenHeight / 2f;
        float bottom = cam.transform.position.y - screenHeight / 2f;

        float x = Mathf.Clamp(transform.position.x, left, right);            //Mathf.Clamp(value, min, max) kiem tra 1 gia tri co nam trong khoan quy dinh ko, neu  ko thi gan lai cho gia tri min hoac max
        float y = Mathf.Clamp(transform.position.y, bottom, top);

        transform.position = new Vector3(x, y, transform.position.z);



        timer += Time.deltaTime;
        Shoot();

        if(GameManager._i.isPaused == true)
        {
            return;
        }


    }


    void Shoot()
    {
        if (timer >= 0.5)
        {
            if (bulletLevel == 1)
            {
                Instantiate(Choose_BulletLevel(), transform.position, transform.rotation);
            }
            else if (bulletLevel == 2)
            {
                Vector3 temp = new Vector3(0.25f, 0f, 0f);
                Instantiate(Choose_BulletLevel(), transform.position + temp, transform.rotation);
                Instantiate(Choose_BulletLevel(), transform.position - temp, transform.rotation);
            }
            else
            {
                Instantiate(Choose_BulletLevel(), transform.position, transform.rotation);
                Instantiate(Choose_BulletLevel(), transform.position, Quaternion.Euler(0f, 0f, 45f));
                Instantiate(Choose_BulletLevel(), transform.position, Quaternion.Euler(0f, 0f, -45f));
            }


            timer = 0;

        }

    }

    public void UpgradeBullet()
    {
        bulletLevel = Mathf.Min(bulletLevel + 1, 3);
    }

    public PlayerBullet Choose_BulletLevel()
    {
        switch (bulletLevel)
        {
            case 2:
                return bulletLevel2;
            case 3:
                return bulletLevel3;
            default:
                return bulletPrefab;
        }
    }
}


// Gioi han pham vi di chuyen cua object minh dang dung la check position - ap dung cho game 2d don gian
// con cach camera bound - lay bien tu camera - ap dung cho game co camera thay doi/di chuyen, muon gioi han theo vung nhin
// collider - dung vat the/bien co collider de chan - ap dung cho game co he thong vat li, tuong, dia hinh, va cham

