using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody2D rb;
    public Transform gun;
    public Transform ShootPoint;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public GameObject CrossHair;
    private GameObject crosshairInstance;

    private Animator _animation;
    private bool IsWalking;

    public KeyCode FireKey;

    Vector2 moveDirection;
    Vector2 mousePosition;
    private float aimAngle;

    private void Start()
    {
        _animation = GetComponent<Animator>();
        // spawn crosshair
        crosshairInstance = Instantiate(CrossHair, Vector3.zero, Quaternion.identity);
    }

    private void Update()
    {
        // movement input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (rb.velocity.x > 0 || rb.velocity.y > 0 || rb.velocity.x < 0 || rb.velocity.y < 0)
        {
            IsWalking = true;
        }

        else
        {
            IsWalking = false;
        }

        _animation.SetBool("IsWalking", IsWalking);

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        

        // shoot input
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(FireKey))
        {
            ShootGun();
        }
    }


    private void FixedUpdate()
    {
        // crosshair naar muis beweegen
        crosshairInstance.transform.position = mousePosition;

        // player movement
        rb.velocity = moveDirection * speed;

        // calculate aim angle
        Vector2 aimDirection = (mousePosition - rb.position).normalized;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        gun.rotation = Quaternion.Euler(0f, 0f, aimAngle);
    }

    public void ShootGun()
    {
        // spawn bullet op shootpoint
        GameObject spawnedBullet = Instantiate(bulletPrefab, ShootPoint.position, Quaternion.identity);

        // rigidbody for bullet
        Rigidbody2D bulletRb = spawnedBullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            // bullet speed
            bulletRb.velocity = ShootPoint.right * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on the prefab. Velocity not applied.");
        }
    }
}
