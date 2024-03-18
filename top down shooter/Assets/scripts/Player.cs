using System.Collections;
using TMPro;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

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

    private SpriteRenderer PlayerSprite;

    public GameObject CrossHair;
    private GameObject crosshairInstance;

    public TextMeshProUGUI txtHealth;
    public TextMeshProUGUI txtPoints;

    public GameObject DeathEffect;
    public GameObject HitEffect;

    public KeyCode FireKey;

    public KeyCode RotLeft;
    public KeyCode RotRight;

    public bool HealthOverride;

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

        PlayerSprite = GetComponent<SpriteRenderer>();

        txtHealth.text = health.ToString();
        txtPoints.text = Points.ToString();
    }

    private void Update()
    {
        Cursor.visible = false;

        // movement input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // animaties aan/uit zetten
        if (rb.velocity.x > 0 || rb.velocity.y > 0 || rb.velocity.x < 0 || rb.velocity.y < 0)
        {
            IsWalking = true;
        }

        else
        {
            IsWalking = false;
        }

        _animation.SetBool("IsWalking", IsWalking);


        // sets positions
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
            txtHealth.text = health.ToString();
            Debug.Log("DEAD");
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        // health niet hoger dan 10
        if (!HealthOverride)
        {
            if (health > 10)
            {
                health = 10;
            }
        }


        while (Input.GetKey(RotLeft))
        {
            gun.Rotate(Vector3.forward * 1f * Time.deltaTime);
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


    public void HealthManager(int dmgDealt, string AddRem)
    {
        if (AddRem == "+")
        {
            health += dmgDealt;
        }
        else if (AddRem == "-")
        {
            health -= dmgDealt;
            Instantiate(HitEffect, transform.position, Quaternion.identity);
            StartCoroutine(PlayerHit(0.1f));
        }
        txtHealth.text = health.ToString();

    }

    public IEnumerator PlayerHit(float Duration)
    {
        float TimeElapsed = 0f;
        while (TimeElapsed < Duration)
        {
            PlayerSprite.color = Color.red;
            TimeElapsed += Time.deltaTime;
            yield return 0;
        }

        PlayerSprite.color = Color.white;
    }

    public void PointManager(int PointsToAdd)
    {
        Points += PointsToAdd;
        txtPoints.text = Points.ToString();
    }

}
