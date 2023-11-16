using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject laser;
    private bool wait;
    public int score;
    public int lives;
    public GameObject spawnPoint;
    private Vector3 spawnPosition;
    private bool invincible;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (wait == false)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(laser, transform.position, transform.rotation);
                wait = true;
                StartCoroutine(Wait());
            }
        }
      
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        wait = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (invincible == false)
        {
            if (collision.gameObject.tag == "CrashEnemy")
            {
                Respawn();
            }
        }
        
            
        
      
    }

    private void Respawn()
    {
        transform.position = spawnPosition;
        lives-= 1;
        StartCoroutine(Invincibility());
    }
    private IEnumerator Invincibility(float interval = 5f)
    {
        invincible = true;
        for (int count = 0; count == 3; count++)
        {
            gameObject.SetActive(!gameObject.activeSelf);
            yield return new WaitForSeconds(interval);
        }
       
        invincible = false;
    }

}
