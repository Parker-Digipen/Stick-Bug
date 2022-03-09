using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Death grim = GetComponent<Death>();
        if (grim != null)
        {
            grim.OnDeath.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Health>().CurrentHealth == 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
