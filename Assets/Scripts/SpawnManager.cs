using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnMultiplier = 1;
    private EnemySpawner[] spawners;
    // Start is called before the first frame update
    void Start()
    {
        //populates spawners array
        spawners = FindObjectsOfType<EnemySpawner>();
        for(int i = 0; i < (int)(GameManager.stage * spawnMultiplier); i++)
        {
            //increases to spawn count at random spawners
            spawners[Random.Range(0, (int)(GameManager.stage * spawnMultiplier))].spawnCount++;
        }
        //spawns things
        GameManager.SpawnEnemies.Invoke();
    }
}
