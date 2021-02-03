using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalEnemyController : MonoBehaviour
{
    private Transform enemies;
    public float speed;

    public GameObject bullet;
    public float fireRate;
    private int moveSpeed;
    private int allChild;
    public GameObject ufo;
    public static bool isUFO;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemies = GetComponent<Transform>();
        allChild = enemies.childCount;
        moveSpeed = 0;
        fireRate = 0.997f;
        isUFO = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value > 0.9995 && !isUFO) 
        {
            isUFO = true;
            Instantiate(ufo, new Vector3(0.0f, 0.0f, 9.0f), new Quaternion());
        }
    }

    void MoveEnemy() 
    {
        enemies.position += Vector3.right * speed;

        foreach (Transform enemy in enemies) 
        {
            if (enemy.position.x < -15 || enemy.position.x > 15) 
            {
                speed = -speed;
                enemies.position += Vector3.back * 0.5f;
                return;
            }

            if (Random.value > fireRate)
            {
                Instantiate(bullet, enemy.position, enemy.rotation);
        }

            if (enemy.position.z <= -4.8) 
            {
                GlobalController.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        


        float remainRatio = (float)enemies.childCount / (float)allChild;

        if (remainRatio < 0.1 && moveSpeed != 4)
        {
            moveSpeed = 4;
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.1f);
        }
        else if (remainRatio < 0.25 && moveSpeed != 3)
        {
            moveSpeed = 3;
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.15f);
        }
        else if (remainRatio < 0.5 && moveSpeed != 2) 
        {
            moveSpeed = 2;
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.20f);
        }
        else if (remainRatio < 0.75 && moveSpeed != 1) 
        {
            moveSpeed = 1;
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }
       
        //speed += (allChild - enemies.childCount) * 1.0f / allChild;

        if (enemies.childCount == 0) 
        {
            GlobalController.isWin = true;
        }
    }
}
