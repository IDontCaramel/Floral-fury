using System;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody2D rb;
    public Transform gun;
    public Transform ShootPoint;
    public float bulletSpeed;
    public GameObject bullet;

    public KeyCode FireKey;

    Vector2 moveDirection;
    Vector2 mousePosition;
    private float aimAngle;

    private void Update()
    {
        while (Input.GetMouseButtonDown(0) || Input.GetKeyDown(FireKey))
        {
            
        }


        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Euler(0f, 0f, aimAngle);
    }

    public void ShootGun()
    {
        GameObject spawnedObject = Instantiate(bullet, ShootPoint.position, Quaternion.identity);

        Rigidbody2D bulletRb = spawnedObject.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.velocity = new Vector2(Mathf.Cos(aimAngle * Mathf.Deg2Rad), Mathf.Sin(aimAngle * Mathf.Deg2Rad)) * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on the prefab. Velocity not applied.");
        }
    }

}
