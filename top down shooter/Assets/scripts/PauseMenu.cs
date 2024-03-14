using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Vector2 mousePosition;

    public GameObject Menu;
    public GameObject cursor;


    private void Start()
    {
    }


    void Update()
    {
        Cursor.visible = false;
        if (Input.GetKeyUp(KeyCode.Escape))
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

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = mousePosition;

    }
}
