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

    public int Points;

    public bool isPatrol;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 patrolTarget;

    public GameObject scorePopUp;

    private void Start()
    {

        // vind de speler en zet die als targer
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found! Make sure it is tagged with 'Player'.");
        }

        patrolTarget = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void Update()
    {
        // checked of het target bestaat
        if (target == null)
        {
            return; 
        }

        // patrol functie idk of we die gaan gebruiken
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


        // death animatie en punten optellen
        if (health <= 0)
        {
            GameObject instance = Instantiate(scorePopUp, transform.position, Quaternion.identity);
            target.GetComponent<Player>().AddPoints(Points);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = "+" + Points;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    // damage doen naar de speler
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }


    // damage van bullets
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }
    }
}
