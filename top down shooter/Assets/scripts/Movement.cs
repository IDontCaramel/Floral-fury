using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody2D rb;
    public Transform gun;

    Vector2 moveDirection;
    Vector2 mousePosition;

    private void Update()
    {
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
}
