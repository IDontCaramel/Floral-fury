using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject HitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(HitEffect, transform.position, Quaternion.identity);
        }
    }
}
