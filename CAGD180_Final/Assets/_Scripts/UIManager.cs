using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
/*
 * Author: [Suazo,Angel & Johnson,Ethan]
 * Last Updated: [12/08/2023]
 * [This script handles UI]
 */

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public LaserEnemyController laserEnemyController;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text currentLevel;
    public TMP_Text highScore;
    public GameObject powerUp;
    public GameObject powerUpSpawn;
    public GameObject laserEnemySpawn;
    public GameObject laserEnemy;
    public GameObject crashEnemySpawn;
    public GameObject crashEnemy;
    public GameObject bossEnemySpawn;
    public GameObject bossEnemy;

    private int amount;

    private bool waiting;

    public int level=0;
    public static int currentHighScore;
    public bool levelInProgress = false;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelInProgress == false && level <= 5)
        {
             
            StartCoroutine(LevelBegin());
            levelInProgress = true;
        }
        if (level == 1 && levelInProgress == true) 

        //scoreText.text = "Score: " + playerController.score;
        livesText.text = "Lives: " + playerController.lives;
        currentLevel.text = "Level: " + level;
        //highScore.text = "High Score: " + currentHighScore;

        if (playerController.score > currentHighScore)
        {
            currentHighScore = playerController.score;
        }
        if (playerController.lives == 0)
        {
           
            SwitchScene("GameOver");
        }
        if (level == 5 && playerController.lives >= 1)
        {
            
            SwitchScene("GameOver");
        }
        if (level == 3 && levelInProgress == false)
        {
            Instantiate(powerUp, powerUpSpawn.transform.position, powerUpSpawn.transform.rotation);
        }
        SpawnEnemies();
        
    }

    private IEnumerator LevelBegin()
    {
        Debug.Log("the level has begun");
        
        yield return new WaitForSeconds(15f);
        level++;
        levelInProgress = false;
        Debug.Log("the level has ended");
        amount = 0;
    }

    private void SwitchScene(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    private void SpawnEnemies()
    {
        if (level <= 1)
        {
            if (amount < 1)
            {
                if (waiting == false)
                {
                    Instantiate(laserEnemy, laserEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);                 
                    Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
                    amount++;
                    waiting = true;
                    StartCoroutine(Wait());
                    
                }
            }
        }
        if (level == 2)
        {

            if (amount < 2)
            {
                if (waiting == false)
                {
                    Instantiate(laserEnemy, laserEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);
                    Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
                    amount++;
                    waiting = true;
                    StartCoroutine(Wait());
                    
                }
            }
        }
        if (level == 3)
        {

            if (amount < 3)
            {
                if (waiting == false)
                {
                    Instantiate(laserEnemy, laserEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);
                    Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
                    amount++;
                    waiting = true;
                    StartCoroutine(Wait());

                }
            }
        }
        if (level == 4)
        {

            if (amount < 4)
            {
                if (waiting == false)
                {
                    Instantiate(laserEnemy, laserEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);
                    Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
                    amount++;
                    waiting = true;
                    StartCoroutine(Wait());

                }
            }
        }
        if (level == 5)
        {

            if (amount < 1)
            {
                if (waiting == false)
                {
                    Instantiate(bossEnemy, bossEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);              
                    amount++;
                    waiting = true;
                    StartCoroutine(Wait());

                }
            }
        }
    }
    private IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(1);
        
        waiting = false;
    }
}
