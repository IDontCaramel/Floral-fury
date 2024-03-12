using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelFrontClouds : MonoBehaviour
{
    public float parallelSpeedSlow;
    public float parallelSpeedFast;
    public float parallelSpeedMedium;

    public bool isBack;
    public bool isMedium;
    Vector3 startPos;
    float repeadWidth;

    private void Start()
    {
        startPos = transform.position;
        repeadWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    private void Update()
    {
        if (isBack)
        {
            transform.Translate(Vector3.left * Time.deltaTime * parallelSpeedSlow);
        }

        else if (isMedium)
        {
            transform.Translate(Vector3.left * Time.deltaTime * parallelSpeedMedium);
        }

        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * parallelSpeedFast);
        }

        if (transform.position.x < startPos.x - repeadWidth)
        {
            transform.position = startPos;
        }
    }
}