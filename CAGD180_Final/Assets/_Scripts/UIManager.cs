using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Runtime.CompilerServices;

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text currentLevel;
    public TMP_Text highScore;
    public GameObject powerUp;
    public GameObject powerUpSpawn;

    public GameObject crashEnemy;
    public GameObject crashEnemySpawn;

    public GameObject laserEnemy;
    public GameObject laserEnemySpawn;

    public GameObject duplicatorEnemy;
    public GameObject duplicatorEnemySpawn;


    public int level;
    private int amount;
    public static int currentHighScore;
    public bool levelInProgress = false;

    private bool waiting;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
        if (levelInProgress == false && level <= 5)
        {

            StartCoroutine(LevelBegin());
            levelInProgress = true;
        }


        scoreText.text = "Score: " + playerController.score;
        livesText.text = "Lives: " + playerController.lives;
        currentLevel.text = "Level: " + level;
        highScore.text = "High Score: " + currentHighScore;

        if (playerController.score > currentHighScore)
        {
            currentHighScore = playerController.score;
        }
        if (playerController.lives == 0)
        {

            SwitchScene("GameOver");
        }
        if (level == 5 && levelInProgress == false && playerController.lives >= 1)
        {

            SwitchScene("GameOver");
        }
        if (level == 3 && levelInProgress == false)
        {
            Instantiate(powerUp, powerUpSpawn.transform.position, powerUpSpawn.transform.rotation);
        }

    }

    private IEnumerator LevelBegin()
    {
        Debug.Log("the level has begun");

        yield return new WaitForSeconds(30f);
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
            if (amount < 2)
            {
                if (waiting == false)
                {
                    Instantiate(laserEnemy, laserEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);
                    Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
                    amount++;
                    StartCoroutine(Wait());
                    waiting = true;
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
                    StartCoroutine(Wait());
                    waiting = true;
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
