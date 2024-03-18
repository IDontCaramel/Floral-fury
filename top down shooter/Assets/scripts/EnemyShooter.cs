using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    public GameObject effect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target) < 4f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0.3f * Time.deltaTime);
            //Instantiate(effect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }
    }

    
}
