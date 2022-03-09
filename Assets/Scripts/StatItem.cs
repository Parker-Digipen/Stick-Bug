using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour
{
    public float[] Stats;
    private PlayerController myPC;
    private void Start() 
    {
        myPC = FindObjectOfType<PlayerController>();
        Stats = new float[8];
        Stats[0] = myPC.speed;
        Stats[1] = myPC.airSpeed;
        Stats[2] = myPC.extraJumps;
        Stats[3] = myPC.jumpForce;
        Stats[4] = myPC.jumpTime;
        Stats[5] = myPC.projectileSpeed;
        Stats[6] = myPC.burstSize;
        Stats[8] = myPC.fireDelay;
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {        
        Stats[Random.Range(0, 8)]++;
        Destroy(this);
    }
}
