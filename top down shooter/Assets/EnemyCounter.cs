using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int AmountOfEnemiesAlive;

    private void Update()
    {
        var childrenList = new List<Transform>();
        foreach (Transform child in transform)
        {

            childrenList.Add(child);
        }

        Transform[] children = childrenList.ToArray();
        AmountOfEnemiesAlive = children.Length;
    }
}
