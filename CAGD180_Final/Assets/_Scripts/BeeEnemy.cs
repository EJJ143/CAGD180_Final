using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    public float speed;
    private float dist;
    private float distMin = -8.25f;
    private float distMax = 8.25f;
    private Vector3 temp;

    public bool goingRight = true;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
