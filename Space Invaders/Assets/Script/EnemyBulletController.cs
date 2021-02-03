using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed;
    private Transform bullet;
    public AudioClip deathKnell;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        bullet.position += Vector3.back * speed;

        if (bullet.position.z <= -8)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Hit an enemy
            Destroy(other.gameObject);
            Destroy(gameObject);
            GlobalController.isPlayerDead = true;
            AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        }
        else if (other.tag == "Base")
        {
            // Hit the base
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
