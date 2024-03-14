using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnerScript : MonoBehaviour
{
    public Transform[] AllSpawners;
    public int numberOfEnemiesAlive;
    public int EnemiesToSpawn;
    public int wave = 0;
    public GameObject[] enemies;
    List<GameObject> AmountOfEnemies = new List<GameObject>();

    public float timeBetweenSpawn;
    public float timer;
    public bool canSpawn = true;

    public GameObject AllenemiesParent;

    private int NumbOfChild = 1;



    public void Start()
    {
        AllSpawners = GetComponentsInChildren<Transform>();
        GoThroughSpawners();
    }

    private void Update()
    {
        WaveManager();
        numberOfEnemiesAlive = AmountOfEnemies.Count;
    }

    public void WaveManager()
    {
        if (numberOfEnemiesAlive > 0)
        {
            Debug.Log("Enemies are not dead");
            return;
        }

        else
        {
            
            for (int i = 0; i < EnemiesToSpawn; i++)
            {
                Debug.Log("hij komt hier");
                if (!canSpawn)
                {
                    timer += Time.deltaTime;
                    if (timer > timeBetweenSpawn)
                    {
                        Debug.Log("Spawn = true");
                        canSpawn = true;
                        timer = 0;
                    }
                }
                if (canSpawn)
                {
                    int RandomEnemiesIndex = Random.Range(0, enemies.Length);
                    Debug.Log(RandomEnemiesIndex);
                    int RandomSpawnerIndex = Random.Range(1, AllSpawners.Length); // Choose a random index from SpawnerPositions
                    Vector3 randomSpawnerPosition = AllSpawners[RandomSpawnerIndex].position;

                    GameObject clonedEnemy = Instantiate(enemies[RandomEnemiesIndex], randomSpawnerPosition, transform.rotation);
                    clonedEnemy.transform.parent = AllenemiesParent.transform;
                    AmountOfEnemies.Add(clonedEnemy);
                    canSpawn = false;
                }
            }
        }
    }
        
    public void GoThroughSpawners()
    {
        foreach (Transform child in AllSpawners)
        {
            Debug.Log(AllSpawners.Length);
            if (child == transform)
                continue;
            child.gameObject.name = "Spawner_" + NumbOfChild.ToString();
            NumbOfChild++;
        }
    }
}
