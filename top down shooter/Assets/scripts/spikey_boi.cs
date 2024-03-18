using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spikey_boi : MonoBehaviour
{
    public float pushForce = 5f; // Adjust this value to control the force applied
    public int damage = 5;

    private bool timeout = false;
    private float timer;

    private void Update()
    {
        //hit timout
        if (timeout)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timeout = false;
                timer = 0;
            }
        }

        else
        {
            timeout = false;
        }
    }


    // duwt de player weg van de spike (werkt heel raar)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 directionToObject = collision.transform.position - transform.position;

        Debug.Log("spikey boi hit");

        Rigidbody2D rbHit = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rbHit != null)
        {
            Vector2 pushDirection = -directionToObject.normalized;
            rbHit.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Player") && !timeout)
        {
            collision.gameObject.GetComponent<Player>().HealthManager(damage, "-");

            timeout = true;
        }
    }
}
