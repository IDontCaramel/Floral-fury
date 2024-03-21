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
    private Transform[] AllSpawners;
    public int numberOfEnemiesAlive;
    public EnemyCounter enemiesalive;
    public int EnemiesToSpawn;
    private int EnemiesThatSpawnedLastTIme = 3;
    public int enemiestoSpawnMultiplier;
    public int wave = 0;
    public GameObject[] enemies;

    public int maxenemiesthatCanSpawn;

    public float timeBetweenSpawn;
    private float timer = 0;
    private bool canSpawn = true;

    public float TimeBetweenWave;
    private float waveTimer;
    private bool NextWave = true;

    public GameObject AllenemiesParent;

    private int NumbOfChild = 1;



    public void Start()
    {
        AllSpawners = GetComponentsInChildren<Transform>();
        GoThroughSpawners();
    }

    private void Update()
    {
        numberOfEnemiesAlive = enemiesalive.AmountOfEnemiesAlive;
        EnemySpawner();
    }

    private void FixedUpdate()
    {
        if (NextWave)
        {
            waveManager();
            NextWave = false;
        }

        else
        {
            waveTimer += Time.deltaTime;
            if (waveTimer > TimeBetweenWave)
            {
                NextWave = true;
                waveTimer = 0;
            }
        }
    }


    public void EnemySpawner()
    {
        for (int i = 0; i < EnemiesToSpawn; i++)
        {
            if (canSpawn)
            {
                Spawner();
                canSpawn = false;
            }

            else if (!canSpawn)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenSpawn)
                {
                    canSpawn = true;
                    timer = 0;
                    EnemiesToSpawn--;
                }
            }
        }
    }

    public void waveManager()
    {
        if (numberOfEnemiesAlive <= 100)
        {
            wave += 1;
            if (EnemiesThatSpawnedLastTIme < maxenemiesthatCanSpawn)
            {
                EnemiesToSpawn = EnemiesThatSpawnedLastTIme + enemiestoSpawnMultiplier;
            }
            else
            {
                EnemiesToSpawn = maxenemiesthatCanSpawn;
            }
            EnemiesThatSpawnedLastTIme = EnemiesToSpawn;
            Debug.Log(EnemiesToSpawn);
        }

        else
        {
            TimeBetweenWave = 5;
            return;
        }



    }

    public void Spawner()
    {
        int RandomEnemiesIndex = Random.Range(0, enemies.Length);
        int RandomSpawnerIndex = Random.Range(1, AllSpawners.Length);
        Vector3 randomSpawnerPosition = AllSpawners[RandomSpawnerIndex].position;

        GameObject clonedEnemy = Instantiate(enemies[RandomEnemiesIndex], randomSpawnerPosition, transform.rotation);
        clonedEnemy.transform.parent = AllenemiesParent.transform;
        numberOfEnemiesAlive += 1;
        return;
    }

    public void GoThroughSpawners()
    {
        foreach (Transform child in AllSpawners)
        {
            if (child == transform)
                continue;
            child.gameObject.name = "Spawner_" + NumbOfChild.ToString();
            NumbOfChild++;
        }
    }
}
