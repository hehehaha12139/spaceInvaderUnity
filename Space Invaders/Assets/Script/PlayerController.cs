using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float speed;
    public float maxBound, minBound;

    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;

    private float nextFire;

    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position + new Vector3(0.0f, 0.0f, 0.5f), bulletSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (player.position.x < minBound && h < 0)
            h = 0;
        else if (player.position.x > maxBound && h > 0)
            h = 0;
        player.position += Vector3.right * h * speed;

    }
}
