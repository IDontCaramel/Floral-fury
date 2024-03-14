using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    public int health;
    public int Points;

    public Rigidbody2D rb;

    public Transform gun;
    public Transform ShootPoint;
    public float bulletSpeed;
    public GameObject bulletPrefab;

    public GameObject CrossHair;
    private GameObject crosshairInstance;

    public TextMeshPro txtHealth;
    public TextMeshPro txtPoints;

    public GameObject DeathEffect;

    public KeyCode FireKey;

    Vector2 moveDirection;
    Vector2 mousePosition;
    private float aimAngle;
    private Animator _animation;
    private bool IsWalking;

    private float ExtraBulletSpeed = 1f;

    private void Start()
    {
        // set animator
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


        // check if dood
        if (health <= 0) 
        {
            health = 0;
            Debug.Log("DEAD");
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
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
            // geeft de bullet extra speed als de speler aan het bewegen is
            if (rb.velocity.magnitude > 0f)
            {
                ExtraBulletSpeed = rb.velocity.magnitude / 10 + 1;
            }

            // bullet speed
            bulletRb.velocity = ShootPoint.right * bulletSpeed * ExtraBulletSpeed;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on the prefab. Velocity not applied.");
        }
    }

    // damaged de speler
    public void TakeDamage(int Damage)
    {
        health -= Damage;
        txtHealth.text = health.ToString();
    }

    // adds to player points
    public void AddPoints(int PointsToAdd)
    {
        //Points += PointsToAdd;
        //txtPoints.text = health.ToString();
    }
    

}
