using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloThere : MonoBehaviour
{
    public GameObject Kenoby;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cursor"))
        {
            Kenoby.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cursor"))
        {
            Kenoby.SetActive(false);
        }
    }
}
