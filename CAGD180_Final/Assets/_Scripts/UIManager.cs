using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text currentLevel;
    public TMP_Text highScore;

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
        
    }

    private IEnumerator LevelBegin()
    {
        Debug.Log("the level has begun");
       
        yield return new WaitForSeconds(60f);
        level++;
        levelInProgress = false;
        Debug.Log("the level has ended");

    }

    private void SwitchScene(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
