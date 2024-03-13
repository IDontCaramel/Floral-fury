using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikey_boi : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("spikey boi hit");
    }
}
