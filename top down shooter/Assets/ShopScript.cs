using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    private bool onItem1 = true;
    private bool onItem2 = false;

    Vector3 bigScale = new Vector3(20.5698f, 42.43313f, 58.69231f);
    Vector3 smallScale = new Vector3(18.5698f, 40.43313f, 58.69231f);

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    private void Update()
    {
        if (onItem1)
        {
            item1.transform.localScale = bigScale;
            item2.transform.localScale = smallScale;
            item3.transform.localScale = smallScale;

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                onItem1 = false;
                onItem2 = true;
            }
        }

        else if (onItem2)
        {
            item1.transform.localScale = smallScale;
            item2.transform.localScale = bigScale;
            item3.transform.localScale = smallScale;

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                onItem1 = false;
                onItem2 = false;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                onItem1 = true;
                onItem2 = false;
            }
        }

        else
        {
            item1.transform.localScale = smallScale;
            item2.transform.localScale = smallScale;
            item3.transform.localScale = bigScale;

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                onItem1 = false;
                onItem2 = true;
            }
        }
    }
}
