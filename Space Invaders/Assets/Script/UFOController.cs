using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    private Transform ufo;
    public float speed;
    public AudioClip deathKnell;
    // Start is called before the first frame update
    void Start()
    {
        ufo = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ufo.position.x < -15 || ufo.position.x > 15)
            speed = -speed;
     
        ufo.position += Vector3.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
            GlobalController.score += 100;
            GlobalEnemyController.isUFO = false;
        }
    }
}
