using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnDeath : MonoBehaviour
{
    public GameObject objectToMake;
    public Vector3 Offset = Vector3.zero;
    public float minRandOffset = 0;
    public float maxRandOffset = 0;

    private void OnDestroy()
    {
        float randOffset = Random.Range(minRandOffset, maxRandOffset);
        Vector3 spawn = Random.insideUnitCircle * randOffset;
        spawn += transform.position + Offset;
        Instantiate(objectToMake, spawn, transform.rotation );
        Invoke("woo", 0.5f);
    }

    void woo()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Death grim = GetComponent<Death>();
        if (grim != null) 
        {
            grim.OnDeath.Invoke();
        }
    }
}
