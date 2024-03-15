using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform target;

    public int damage;
    public int health;
    public GameObject deathEffect;

    public int PointsWorth;

    public bool isPatrol;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 patrolTarget;

    public GameObject scorePopUp;


    public float visionRange;
    private GameObject player;

    public LayerMask CanSee;

    private void Start()
    {

        // vind de speler en zet die als targer
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found");
        }

        patrolTarget = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void Update()
    {
        // checked of het target bestaat
        if (target == null)
        {
            Debug.Log("target not found");
            return;
        }



        // checks of de speler in range en er geen objecten tussen zitten
        if (player != null)
        {
            Vector2 directionToPlayer = player.transform.position - transform.position;
            Debug.DrawRay(transform.position, directionToPlayer, Color.cyan);

            if (directionToPlayer.magnitude <= visionRange)
            {
                RaycastHit2D ray = Physics2D.Raycast(transform.position, directionToPlayer, visionRange);

                if (ray.collider != null)
                {
                    Debug.Log("Ray hit: " + ray.collider.gameObject.name);
                }
                else
                {
                    Debug.Log("Ray did not hit anything.");
                }

                if (ray.collider != null && ray.collider.gameObject == player)
                {
                    Debug.Log("player found");
                    isPatrol = false;
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
                }
                else
                {
                    Debug.Log("player not found");
                    isPatrol = true;
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
                }

            }
            else
            {
                Debug.Log("player exits idk");
                isPatrol = true;
            }
        }
        else
        {
            Debug.Log("Target or player is null");
        }


        // death animatie en punten optellen
        if (health <= 0)
        {
            GameObject instance = Instantiate(scorePopUp, transform.position, Quaternion.identity);
            target.GetComponent<Player>().Points += PointsWorth;
            instance.GetComponentInChildren<TextMeshProUGUI>().text = "+" + PointsWorth;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    private void FixedUpdate()
    {
        // patrol functie 
        if (isPatrol)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolTarget, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, patrolTarget) < 0.2f)
            {
                patrolTarget = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // damage van bullets
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }

        // damage doen naar de speler
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
