using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }
}