using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 6)
        {
            GetComponentInChildren<Rigidbody2D>().AddForce((other.gameObject.GetComponent<Rigidbody2D>().velocity + Vector2.one) * new Vector2(30, 30));
            Destroy(this);
        }
    }
}
