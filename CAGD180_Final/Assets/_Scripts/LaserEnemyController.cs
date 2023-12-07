using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LaserEnemyController : MonoBehaviour
{
    public float speed;
    private float dist;
    private float distMin = -8.25f;
    private float distMax = 8.25f;
    private Vector3 temp;

    public bool goingRight = true;
    public PlayerController playerController;
    public GameObject laserPrefab;

    public float laserSpawnRate = 0.5f;
    public float laserDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLaser", 1, laserSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void SpawnLaser()
    {
        Instantiate(laserPrefab, transform.position, transform.rotation);
    }

    private void Move()
    {
        if (goingRight)
        {
            if (transform.position.x >= -dist)
            {
                temp = Vector3.left;
                SetRandomDirectionSwitch();
                goingRight = false;
            }
        }
        else
        {
            if (transform.position.x <= dist)
            {
                temp = Vector3.right;
                SetRandomDirectionSwitch();
                goingRight = true;
            }
        }
        transform.position += temp * Time.deltaTime * speed;
    }
    private void SetRandomDirectionSwitch()
    {
        dist = Random.Range(distMin, distMax);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            playerController.score += 10;
        }
    }

}
