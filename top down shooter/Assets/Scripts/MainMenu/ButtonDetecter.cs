using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonDetecter : MonoBehaviour
{
    public bool onStart = false;
    public bool onHelp = false;
    public bool onExit = false;

    public GameObject Start;
    public GameObject Help;
    public GameObject Exit;

    public GameObject customcursor;
    

    Vector2 MousePosition;


    public bool usingKeyboard = false;

    public double uitrek = 1.5;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (usingKeyboard)
            {
                Start.transform.localScale = new Vector2((float)1.3, (float)1.3);
                Help.transform.localScale = new Vector2((float)1.3, (float)1.3);
                Exit.transform.localScale = new Vector2((float)1.3, (float)1.3);
                usingKeyboard = false;
                customcursor.SetActive(true);
            }

            else
            {
                onStart = true;
                usingKeyboard = true;
                customcursor.SetActive(false);
            }
        }

        if (usingKeyboard)
        {
            if (onStart)
            {
                Start.transform.localScale = new Vector2((float)uitrek, (float)uitrek);
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Start.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    Help.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    Exit.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    onStart = false;
                    onHelp = true;
                    onExit = false;
                }
            }

            else if (onHelp)
            {

                Help.transform.localScale = new Vector2((float)uitrek, (float)uitrek);

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Start.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    Help.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    Exit.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    onStart = false;
                    onHelp = false;
                    onExit = true;
                }

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Start.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    Help.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    Exit.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    onStart = true;
                    onHelp = false;
                    onExit = false;
                }
            }

            else
            {
                Exit.transform.localScale = new Vector2((float)uitrek, (float)uitrek);

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Start.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    Help.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    Exit.transform.localScale = new Vector2((float)1.3, (float)1.3);
                    onStart = false;
                    onHelp = true;
                    onExit = false;
                }
            }
        }

        else
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Cursor.visible = false;
            customcursor.transform.position = MousePosition;
        }
    }
}
