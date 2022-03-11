using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health temp;
        if(collision.gameObject.TryGetComponent<Health>(out temp))
        {
            temp.ChangeHealth(-1);
        }
        Destroy(this.gameObject);
    }
}
