using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Vector2 mousePosition;

    public GameObject Menu;
    public GameObject cursor;
    

    public GameObject BuyMenu;


    private void Start()
    {
    }


    void Update()
    {
        Cursor.visible = false;
        if (Input.GetKeyUp(KeyCode.Escape) && !BuyMenu.activeSelf)
        {
            if (!Menu.activeSelf)
            {
                Menu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Menu.SetActive(false);
                Time.timeScale = 1;
            }
        }


        if (Input.GetKeyDown(KeyCode.B) && !Menu.activeSelf) 
        {
            if (BuyMenu.activeSelf)
            {
                Time.timeScale = 1;
                BuyMenu.SetActive(false);
            }

            else
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                BuyMenu.SetActive(true);
            }
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = mousePosition;

    }
}
