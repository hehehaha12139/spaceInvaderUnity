using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float health;
    public Material startMat;
    public Material destroyMat;
    private Renderer rend;
    private float curHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Setting health
        curHealth = health;

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = startMat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "EnemyBullet") 
        {
            curHealth -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0) 
            Destroy(gameObject);
        rend.material.Lerp(startMat, destroyMat, (health - curHealth) / health);
    }
}
