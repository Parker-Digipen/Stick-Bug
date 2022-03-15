using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public float sceneChangeDelay;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SceneSwap", sceneChangeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneSwap()
    {
        SceneManager.LoadScene("EndScene");
    }
}
