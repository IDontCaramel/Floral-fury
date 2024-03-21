using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDetecter : MonoBehaviour
{
    public bool onStart = false;
    public bool onHelp = false;
    public bool onExit = false;

    public Scene[] allMaps;

    public GameObject Start;
    public GameObject Help;
    public GameObject Exit;

    public GameObject customcursor;
    

    Vector2 MousePosition;

    public GameObject HelpMenu;

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
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    RandomMap();
                }

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

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    HelpMenuOpener();
                }

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
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    QuitGame();
                }
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

    public void RandomMap()
    {
        int randomMapIndex = Random.Range(1, allMaps.Length);
        SceneManager.LoadScene("Map " + randomMapIndex.ToString());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HelpMenuOpener()
    {
        HelpMenu.SetActive(true);
    }
}
