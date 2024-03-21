using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    private bool onItem1 = false;
    private bool onItem2 = false;

    public int Points;

    private bool usingMouse = true;

    Vector3 bigScale = new Vector3(20.5698f, 42.43313f, 58.69231f);
    Vector3 smallScale = new Vector3(18.5698f, 40.43313f, 58.69231f);

    private int Item1Price = 750;
    private int Item2Price = 1000;
    private int Item3Price = 500;

    public GameObject Sold1;
    public GameObject Sold2;
    public GameObject Sold3;

    public Player playerScript;
    public Enemy enemyScript;
    public Enemy enemyScript2;
    public Enemy enemyScript3;
    public Enemy enemyScript4;
    public Enemy enemyScript5;
    public Enemy enemyScript6;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (usingMouse)
            {
                onItem1 = true; onItem2 = false;
                usingMouse = false;
            }

            else
            {
                usingMouse = true;
                onItem1 = false; onItem2 = false;
            }
        }

        if (!usingMouse)
        {
            usingMouse = false;

            if (onItem1)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    Item1();

                }

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
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    Item2();
                }

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
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    Item3();
                }

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

        else
        {
            item1.transform.localScale = smallScale;
            item2.transform.localScale = smallScale;
            item3.transform.localScale = smallScale;
            usingMouse = true;
        }
    }

    public bool CheckIfEnough(int ItemPrice)
    {

        if (playerScript.Points >= ItemPrice)
        {
            return true;
        }

        return false;
    }

    public void Item1()
    {
        if (CheckIfEnough(Item1Price))
        {
            playerScript.Points = playerScript.Points - Item1Price;
            enemyScript.dmg = 2;
            enemyScript2.dmg = 2;
            enemyScript3.dmg = 2;
            enemyScript4.dmg = 2;
            enemyScript5.dmg = 2;
            enemyScript6.dmg = 2;

            Sold1.SetActive(true);
        }

        else
        {
            Debug.Log("Not enough Points!");
        }
    }

    public void Item2()
    {
        if (CheckIfEnough(Item2Price))
        {
            playerScript.Points = playerScript.Points - Item2Price;
            playerScript.TrippleShot = true;

            Sold2.SetActive(true);
        }

        else
        {
            Debug.Log("Not enough Points!");
        }
    }

    public void Item3()
    {
        if (CheckIfEnough(Item3Price))
        {
            playerScript.Points = playerScript.Points - Item3Price;
            playerScript.HealthOverride = true;
            playerScript.HealthManager(15, "+");

            Sold3.SetActive(true);
        }

        else
        {
            Debug.Log("Not enough Points!");
        }
    }
}
