using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject laser;
    public GameObject laser2;
    private bool wait;
    private bool powerUp = false;
    public int score;
    public int lives;
    public GameObject spawnPoint;
    private Vector3 spawnPosition;
    public bool invincible;
    public CrashEnemyController crashEnemyController;
    public 
    
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
                if (powerUp == true)
                {
                    Instantiate(laser2, transform.position, transform.rotation);
                    wait = true;
                    StartCoroutine(Wait());
                    
                }
                else
                {
                    Instantiate(laser, transform.position, transform.rotation);
                    wait = true;
                    StartCoroutine(Wait());
                }
                
            }
        }

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        wait = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (invincible == false)
        {
            if (other.gameObject.tag == "CrashEnemy" && invincible == false)
            {
                invincible = true;
                Respawn();
            }
        }
        if (other.gameObject.tag == "Powerup")
        {
            powerUp = true;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "EnemyLaser" && invincible == false)
        {
            invincible = true;
            Respawn();
        }



    }

    private void Respawn()
    {
        transform.position = spawnPosition;
        lives -= 1;
        StartCoroutine(Invincibility());
    }
    private IEnumerator Invincibility()
    {
        
        yield return new WaitForSeconds(5f);

        invincible = false;
    }

}
