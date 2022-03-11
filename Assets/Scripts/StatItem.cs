using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour
{
    public float[] Stats;
    private PlayerController myPC;
    private void Start() 
    {

    }
    private void OnCollisionEnter2D(Collision2D other) 
    {        
        int statChange = 0;
        statChange = Random.Range(0, 8);
        switch (statChange)
        {
            case 0:
            GameManager.Stats[0] += 10;
            break;
            case 1:
            GameManager.Stats[1] += 5;
            break;
            case 2:
            GameManager.Stats[2]++;
            break;
            case 3:
            GameManager.Stats[3]++;
            break;
            case 4:
            GameManager.Stats[4] += 50;
            break;
            case 5:
            GameManager.Stats[5] += 0.5f;
            break;
            case 6:
            GameManager.Stats[6]++;
            break;
            case 7:
            GameManager.Stats[7] -= 0.2f;
            break;
            case 8:
            GameManager.Stats[8]++;
            break;
            
        }
        Destroy(this);
    }
}
