using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnMultiplier = 1;
    private EnemySpawner spawners;
    // Start is called before the first frame update
    void Start()
    {
        spawners = FindObjectOfType<EnemySpawner>();
        for(int i = 0; i < (int)(GameManager.stage * spawnMultiplier); i++)
        {
             
        }   
    }
}
