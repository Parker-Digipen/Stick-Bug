/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: Should be on it's own game object likely alone, only one will exist at a time, handles variables and events more global affecting
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //allow this component to be grabbed from anywhere and make sure only one exists
    public static GameManager Instance;
    public static int stage;
    //event to listen to for the score change
    public static UnityEvent ScoreUpdate = new UnityEvent();
    public static UnityEvent SpawnEnemies = new UnityEvent();
    public static float[] Stats = new float[9];

    //score property and int behind it
    private static int _score = 0;
    public static int score
    {
        
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            ScoreUpdate.Invoke();
        }
    }


    //when made make sure this is the only manager, and make the manager persistant through levels
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public static void ResetGame()
    {
        score = 0;
    }

    public void OnDeath()
    {
        SceneManager.LoadScene("EndScene");
        print("Dying!!!");
        //Invoke("ChangeScene", 2);
       StartCoroutine(SceneChangeDelay());
    }

    public void ChangeScene()
    {
        print("Dead!!!");
        Debug.Log("Dead");
        
    }
    private IEnumerator SceneChangeDelay()
    {
        yield return new WaitForSeconds(2.0f);
        print("Dead!!!");
        Debug.Log("Other dead");
        SceneManager.LoadScene(2);
    }
}
