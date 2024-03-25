using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public ButtonDetecter detecter;
    public GameObject HelpMenu;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("on");
        collision.gameObject.transform.localScale = new Vector2((float)1.5, (float)1.5);
        if (Input.GetMouseButtonDown(0) && collision.CompareTag("StartButton"))
        {
            detecter.RandomMap();
        }

        if (Input.GetMouseButtonDown(0) && collision.CompareTag("HelpButton"))
        {
            HelpMenu.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && collision.CompareTag("ExitButton"))
        {
            Application.Quit();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("leave");
        collision.gameObject.transform.localScale = new Vector2((float)1.3, (float)1.3);
    }
}
