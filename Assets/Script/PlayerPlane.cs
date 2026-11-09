
using UnityEngine;

public class PlayerPlane : MonoBehaviour
{
    public float speed = 8f;
    public float acceleration = 2f;
    public PlayerBullet bulletPrefab;
    public PlayerBullet bulletLevel2;
    public PlayerBullet bulletLevel3;
    public int bulletLevel = 1;
    public float timer = 0f;
    public int health = 10;
    public int point = 0;
    public Sprite[] selectablePlane;
    [Header("Shield Booster")]
    public float shieldDuration = 5f;
    public float shieldCoolDown = 30f;
    public bool IsShieldActive { get; private set; }
    private float shieldEndTime;
    private float shieldReadyTime;
    [SerializeField] private PlayerShield shieldPrefabs;
    private PlayerShield shieldInstance;

    [Header("Double Booster")]
    public float doubleBoosterDuration = 5f;
    public float doubleBoosterCoolDown = 60f;
    public bool IsDoubleBoosterActive { get; private set; }
    private float doubleBoosterEndTime;
    private float doubleBoosterReadyTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int planeIndex = PlayerPrefs.GetInt("SelectedPlaneIndex", 0);
        SpriteRenderer planeRenderer = GetComponent<SpriteRenderer>();
        if (planeRenderer != null && selectablePlane != null && selectablePlane.Length > 0)
        {
            planeIndex = Mathf.Clamp(planeIndex, 0, selectablePlane.Length - 1);
            planeRenderer.sprite = selectablePlane[planeIndex];
        }


        transform.position = new Vector3(0, -3, 0);  // c# ko cho phep viet lenh thuc thi bên ngoài method, nen bat buoc phai viet ben trong 1 method nao do

        GameManager._i.BeginGame();
    }

    // Update is called once per frame



    void Update()
    {

        if (GameManager._i.isPaused || GameManager._i.isEndGame)
        {
            return;
        }

        if (IsShieldActive && Time.time >= shieldEndTime)
        {
            IsShieldActive = false;
            Destroy(shieldInstance.gameObject);
        }

        if (IsDoubleBoosterActive && Time.time >= doubleBoosterEndTime)
        {
            IsDoubleBoosterActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Q)) ActivateShield();

        if (Input.GetKeyDown(KeyCode.E)) ActivateDoubleBooster();


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

        transform.position += direction * speed * Time.deltaTime;
        float x = Mathf.Clamp(transform.position.x, CameraCam.cmr.left, CameraCam.cmr.right);
        float y = Mathf.Clamp(transform.position.y, CameraCam.cmr.bottom, CameraCam.cmr.top);
        transform.position = new Vector3(x, y, transform.position.z);

        timer += Time.deltaTime;
        Shoot();
    }

    void ActivateShield()
    {
        if (Time.time < shieldReadyTime) return;

        IsShieldActive = true;
        shieldEndTime = Time.time + shieldDuration;
        shieldReadyTime = Time.time + shieldCoolDown;
        shieldInstance = Instantiate(shieldPrefabs, transform);
        shieldInstance.transform.localPosition = Vector3.zero;
    }

    void ActivateDoubleBooster()
    {
        if (Time.time < doubleBoosterReadyTime) return;

        IsDoubleBoosterActive = true;
        doubleBoosterEndTime = Time.time + doubleBoosterDuration;
        doubleBoosterReadyTime = Time.time + doubleBoosterCoolDown;
    }

    void SprawnPlayerBullet(Vector3 position, Quaternion rotation)
    {
        PlayerBullet bullet = Instantiate(Choose_BulletLevel(), position, rotation);
        if (IsDoubleBoosterActive)
        {
            bullet.damage *= 2;
        }
    }

    void Shoot()
    {
        float fireInterval = IsDoubleBoosterActive ? 0.25f : 0.5f;
        if (timer >= fireInterval)
        {
            if (bulletLevel == 1)
            {
                SprawnPlayerBullet(transform.position, transform.rotation);

            }
            else if (bulletLevel == 2)
            {
                Vector3 temp = new Vector3(0.25f, 0f, 0f);
                SprawnPlayerBullet(transform.position + temp, transform.rotation);
                SprawnPlayerBullet(transform.position - temp, transform.rotation);

            }
            else
            {
                SprawnPlayerBullet(transform.position, transform.rotation);
                SprawnPlayerBullet(transform.position, Quaternion.Euler(0f, 0f, 45f));
                SprawnPlayerBullet(transform.position, Quaternion.Euler(0f, 0f, -45f));

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

