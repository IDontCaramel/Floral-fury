using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    public GameObject effect;
    public float OriginalSpeed;
    public float ShootRange;

    private float shootTimer = 0f;
    public float timeBetweenShots = 3f;

    private bool CanShoot = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        OriginalSpeed = gameObject.GetComponent<Enemy>().speed;

    }

    private void Update()
    {
        Vector2 playerDirection = player.transform.position - transform.position;

        Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);

        if (playerDirection.magnitude < ShootRange)
        {
            Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);

            gameObject.GetComponent<Enemy>().speed = 0.1f;

            CanShoot = true;
        }
        else
        {
            CanShoot = false;
            gameObject.GetComponent<Enemy>().speed = OriginalSpeed;
        }

        if (CanShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= timeBetweenShots)
            {
                Shoot();
                shootTimer = 0f;
            }
        }

    }

    private void Shoot()
    {
        // Put your shooting logic here
    }


}
