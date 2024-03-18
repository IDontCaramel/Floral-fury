using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    public GameObject effect;
    public float OriginalSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        OriginalSpeed = gameObject.GetComponent<Enemy>().speed;

    }

    private void Update()
    {
        Vector2 testray = player.transform.position - transform.position;
        Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
        if (Vector2.Distance(transform.position, target) > 4f)
        {
            Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            Debug.Log("close to player");

            gameObject.GetComponent<Enemy>().speed = 0.2f;
            //Instantiate(effect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<Enemy>().speed = OriginalSpeed;
        }
    }

    
}
