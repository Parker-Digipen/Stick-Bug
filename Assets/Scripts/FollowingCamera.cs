/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: Addd to the main camera and the target is what it will try to follow, includes screen shake to be called as needed.
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject target;

    public float snapSpeed = 0.5f;

    public float yMax = 10;
    public float yMin = 0;

    
    public float xMax = 0;
    public float xMin = 0;

    public float shakeTime = 0;
    public float shakeMagnitude = 0;

  
    public Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //testing
       /* if(Input.GetKeyDown(KeyCode.G))
        {
            TriggerShake(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            TriggerShake(1, 3);
        }*/
    }

    private void FixedUpdate()
    {
        if (target != null)
        {

            newPos.z = transform.position.z;
            newPos = target.transform.position;

            if (shakeTime > 0)
            {
                newPos += Random.insideUnitSphere.normalized * shakeMagnitude;
                shakeTime -= Time.fixedDeltaTime;
            }
            else
            {
                shakeTime = 0;
                shakeMagnitude = 0;
            }



            newPos = Vector3.Lerp(transform.position, newPos, snapSpeed);

            if (newPos.x > xMax)
                newPos.x = xMax;
            if (newPos.x < xMin)
                newPos.x = xMin;
            if (newPos.y > yMax)
                newPos.y = yMax;
            if (newPos.y < yMin)
                newPos.y = yMin;

            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }
    }

    public void TriggerShake(float time, float magnitude)
    {
        if(shakeTime < time)
        {
            shakeTime = time;
        }
        if(shakeMagnitude < magnitude)
        {
            shakeMagnitude = magnitude;
        }
    }

}
