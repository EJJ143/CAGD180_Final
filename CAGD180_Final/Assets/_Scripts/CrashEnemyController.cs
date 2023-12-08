using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEnemyController : MonoBehaviour
{
    private bool waiting = false;
    private bool attacking = false;
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
        Move();
        //Attack();
        //if (attacking == false && bounceTimes <= 4)
        //{
        //    
        //}
        //if (bounceTimes >= 4)
        //{
        //   transform.position += -transform.right * speed * Time.deltaTime;
        //    if (transform.position.x < -8)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
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

    /* private void Attack()
     {
         if (waiting == false)
         {

             while (transform.position.y >= -5)
             {
                 transform.position += Vector3.down * speed * Time.deltaTime;
             }

             if (transform.position.y >= 4.25f)
             {
                 count++;
                 attacking = false;
             }
             if (count == 1)
             {
                 StartCoroutine(Wait());
                 waiting = true;
             }
        

     */

    private IEnumerator Wait()
    {
        Debug.Log("wait started");

        yield return new WaitForSeconds(5f);
        waiting = false;
        Debug.Log("wait ended");
        count = 0;
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
