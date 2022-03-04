using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDeath : MonoBehaviour
{
public float life = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathTimer());
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
