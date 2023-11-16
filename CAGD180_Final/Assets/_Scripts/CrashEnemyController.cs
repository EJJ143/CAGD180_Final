using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEnemyController : MonoBehaviour
{
    private bool waiting = false;
    public float speed;
    private int count;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        
        Attack();
    }


    private void Attack()
    {
        if (waiting == false)
        {


            transform.position += -transform.up * speed * Time.deltaTime;
            if (transform.position.y <= -5)
            {
                transform.Rotate(0f, 0f, 180f);

            }
            if (transform.position.y >= 6)
            {
                transform.Rotate(0f, 0f, 180f);
                count++;
            }
            if (count == 2)
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
}
