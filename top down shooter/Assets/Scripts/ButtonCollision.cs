using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    public GameObject item1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cursor"))
        {
            item1.transform.localScale = new Vector3(20.5698f, 42.43313f, 58.69231f);
        }

        else
        {
            Debug.Log("It Dont work");
        }
    }
}
