using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Vector2 mousePosition;

    public GameObject Menu;
    public GameObject cursor;

    public bool isInBuyMenu = false;

    public GameObject BuyMenu;
    public GameObject DeathMenu;


    private void Start()
    {
    }

    public void Dead()
    {
        DeathMenu.SetActive(true);
        cursor.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!Menu.activeSelf)
            {
                cursor.SetActive(true);
                Menu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Menu.SetActive(false);
                Time.timeScale = 1;
                cursor.SetActive(false);
            }
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            if (!BuyMenu.activeSelf)
            {
                cursor.SetActive(true);
                BuyMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                BuyMenu.SetActive(false);
                Time.timeScale = 1;
                cursor.SetActive(false);
            }
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = mousePosition;

    }
}
