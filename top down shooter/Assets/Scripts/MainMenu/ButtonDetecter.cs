using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetecter : MonoBehaviour
{
    public bool onStart = true;
    public bool onHelp = false;
    public bool onExit = false;

    public SpriteRenderer ExitWorst;
    public SpriteRenderer StartWorst;
    public SpriteRenderer HelpWorst;

    public Sprite onStartsprite;
    public Sprite onHelpsprite;
    public Sprite onExitsprite;

    public Sprite StartSprite;
    public Sprite HelpSprite;
    public Sprite ExitSprite;

    private void Update()
    {
        if (onStart)
        {
            StartWorst.sprite = onStartsprite;
            HelpWorst.sprite = HelpSprite;
            ExitWorst.sprite = ExitSprite;

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                onStart = false;
                onHelp = true;
                onExit = false;
            }
        }

        else if (onHelp)
        {
            StartWorst.sprite = StartSprite;
            HelpWorst.sprite = onHelpsprite;
            ExitWorst.sprite = ExitSprite;

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                onStart = false;
                onHelp = false;
                onExit = true;
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                onStart = true;
                onHelp = false;
                onExit = false;
            }
        }

        else
        {
            StartWorst.sprite = StartSprite;
            HelpWorst.sprite = HelpSprite;
            ExitWorst.sprite = onExitsprite;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                onStart = false;
                onHelp = true;
                onExit = false;
            }
        }
    }
}
