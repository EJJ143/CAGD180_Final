using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.SceneManagement;
/*
 * Author: [Suazo,Angel & Johnson,Ethan]
 * Last Updated: [12/08/2023]
 * [This script handles UI]
 */

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text currentLevel;
    public TMP_Text highScore;
    public GameObject powerUp;
    public GameObject powerUpSpawn;
    public GameObject enemySpawn;

    public int level=0;
    public static int currentHighScore;
    public bool levelInProgress = false;
    // Start is called before the first frame update
    void Start()
    {
      
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

    }

    private void SwitchScene(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
