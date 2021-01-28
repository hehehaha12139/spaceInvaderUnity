using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour
{
    public static bool isPlayerDead;
    public static int score;
    public static bool isWin;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerDead = false;
        isWin = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead || isWin) 
        {
            if (Input.GetKey(KeyCode.R)) 
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("LevelScene");
            }
        }
    }
}
