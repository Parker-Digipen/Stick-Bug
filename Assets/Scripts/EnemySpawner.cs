using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int spawnCount;
    public int spawnDelay;
    public GameObject toSpawn;
    public bool facingRight;
    void go()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            GameObject enemy = Instantiate(toSpawn, transform.position, transform.rotation);
            enemy.GetComponent<PatrolEnemy>().movingRight = facingRight;

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
