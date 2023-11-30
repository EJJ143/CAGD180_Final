using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEnemyController : MonoBehaviour
{
    private bool waiting = false;
    private bool attacking = false;
    private bool goingRight;
    public float speed;
    private int count;
    private int bounceTimes;
    public PlayerController playerController;
    public GameObject rightPoint;
    public GameObject leftPoint;
    
    public Vector3 rightPos;
    private Vector3 leftPos;
    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        rightPos = rightPoint.transform.position;
        leftPos = leftPoint.transform.position;
        
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {      
        Attack();
        if (attacking == false && bounceTimes <= 4)
        {
            OnScreen();
        }
        if (bounceTimes >= 4)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
            if (transform.position.x < -8)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnScreen()
    {
        if (transform.position.x > 5)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
           
        }
        else
        {
            if (transform.position.x >= 5)
            {
                goingRight = false;
                bounceTimes++;
            }

            if (transform.position.x <= -5)
            {
                goingRight = true;
                bounceTimes++;
            }
            if (goingRight == true)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position += -transform.right * speed * Time.deltaTime;
            }
        }
       
    }

    private void Attack()
    {
        if (waiting == false)
        {
            attacking = true;
            transform.position += -transform.up * speed * Time.deltaTime;
            if (transform.position.y <= -5)
            {
                transform.Rotate(0f, 0f, 180f);

            }
            if (transform.position.y >= 4.25f)
            {
                transform.Rotate(0f, 0f, 180f);
                count++;
                attacking = false;
            }
            if (count == 1)
            {
                StartCoroutine(Wait());
            }
        }
    }
    private IEnumerator Wait()
    {
        Debug.Log("wait started");
        waiting = true;
        yield return new WaitForSeconds(5f);
        waiting = false;
        Debug.Log("wait ended");
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            hit = true;
        }
    }
}
