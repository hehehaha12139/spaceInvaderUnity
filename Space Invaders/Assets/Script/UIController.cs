using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Transform UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalController.isPlayerDead) 
        {
            GameObject gameOverUI = UI.Find("GameOver").gameObject;
            gameOverUI.GetComponent<Text>().enabled = true;

            GameObject reStartUI = UI.Find("Restart").gameObject;
            reStartUI.GetComponent<Text>().enabled = true;
        }

        if (GlobalController.isWin)
        {
            GameObject gameOverUI = UI.Find("Win").gameObject;
            gameOverUI.GetComponent<Text>().enabled = true;

            GameObject reStartUI = UI.Find("Restart").gameObject;
            reStartUI.GetComponent<Text>().enabled = true;
        }

        GameObject scoreUI = UI.Find("Score").gameObject;
        scoreUI.GetComponent<Text>().text = "Score: " + GlobalController.score;
    }
}
