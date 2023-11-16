using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEnemyController : MonoBehaviour
{
    private bool waiting;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
    }

    private void Movement()
    {
        if (transform.position.y <= -6)
        {
            transform.Rotate(0f, 0f, 180f);
            transform.position += -transform.up * speed * Time.deltaTime;
        }
        if (transform.position.y >= 6)
        {
            transform.Rotate(0f, 0f, 180f);
            transform.position += -transform.up * speed * Time.deltaTime;
        }
        
    }
    
    private IEnumerator Attacking()
    {
        yield return new WaitForSeconds(5f);
    }
}
