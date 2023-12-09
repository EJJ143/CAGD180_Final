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
    
    public GameObject laserPrefab;
    

    private int score;

    public float laserSpawnRate = 2f;
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
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= distMax)
            {
                goingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= distMin)
            {
                goingRight = true;
            }
        }


    }
    //private void SetRandomDirectionSwitch()
    //{
    //    dist = Random.Range(distMin, distMax);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            score += 10;
        }
    }

}
