using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int Worth = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // voegt health toe aan de speler
            collision.gameObject.GetComponent<Player>().HealthManager(Worth, "+");
            Destroy(gameObject);
        }
    }
}
