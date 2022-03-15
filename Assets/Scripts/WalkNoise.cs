using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkNoise : MonoBehaviour
{
    PlayerController myPC;
    Rigidbody2D pcRB;
    AudioSource mySrc;
    public AudioClip loopy;
    // Start is called before the first frame update
    void Start()
    {
        mySrc = GetComponent<AudioSource>();
        myPC = FindObjectOfType<PlayerController>();
        pcRB = myPC.gameObject.GetComponent<Rigidbody2D>();
        //mySrc.PlayOneShot(loopy);
        mySrc.loop = true;
        }

    // Update is called once per frame
    void Update()
    {
        
        /*
        if(pcRB.velocity.x != 0 && myPC.isGrounded)
        {
            mySrc.UnPause();
        }
        else
        {
            mySrc.Pause();
        }
        */
        if(Input.GetAxisRaw("Horizontal") != 0 && myPC.isGrounded)
        {
            
            if(!mySrc.isPlaying)
                mySrc.Play();
                
        }
        else
        {
            if(mySrc.isPlaying)
                mySrc.Stop();
        }
    }
}
