using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip deathKnell;
    void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
            GlobalController.score += 10;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

   
}
