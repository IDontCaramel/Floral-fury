using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class deathScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI wave;

    public Player PlayerScript;
    public EnemySpawnerScript enemySpawner;


    void Start()
    {
        score.text = PlayerScript.Points.ToString();
        wave.text = enemySpawner.wave.ToString();
    }


}
