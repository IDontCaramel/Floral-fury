using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody2D rb;
    public Transform Hand;
    public KeyCode FireKey;

    private Vector2 MoveDirection;
    private Vector2 MousePosition;

    private void Update()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2(MoveX, MoveY).normalized;
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (Input.GetButton(FireKey)) {
        //    Shoot();
        //}
    }

    private void FixedUpdate()
    {
        rb.velocity = MoveDirection * speed;

        Vector2 AimDirection = MousePosition - rb.position;
        float AimAngle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;

        // Convert AimAngle to a Quaternion
        Quaternion rotation = Quaternion.Euler(0f, 0f, AimAngle);
        Hand.rotation = rotation;
    }
}
