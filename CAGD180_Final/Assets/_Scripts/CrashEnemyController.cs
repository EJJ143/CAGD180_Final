using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEnemyController : MonoBehaviour
{
    private bool waiting = false;
    private bool goingDown;
    private bool goingRight = false;
    public float speed;
    private int count;
    private int bounceTimes;
    public PlayerController playerController;
    private float dist;
    private float distMin = -8;
    private float distMax = 8;
    private Vector3 temp;



    // Start is called before the first frame update
    void Start()
    {

        
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        
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
            if(transform.position.x <= distMin)
            {
                goingRight=true;
            }
        }


    }

    private void Attack()
    {
        if (waiting == false)
        {
            if (goingDown == true)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
            else
            {
                if (transform.position.y >= 3.5)
                {
                    waiting = true;
                    StartCoroutine(Wait());
                }
                transform.position += Vector3.up * speed * Time.deltaTime;

            }
            if (transform.position.y <= -4)
            {
                goingDown = false;
            }         
        }
        else
        {
            Move();
        }
    } 

    private IEnumerator Wait()
    {
        Debug.Log("wait started");

        yield return new WaitForSeconds(5f);
        waiting = false;
        goingDown = true;
        Debug.Log("wait ended");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            playerController.score += 5;
        }
    }
}
