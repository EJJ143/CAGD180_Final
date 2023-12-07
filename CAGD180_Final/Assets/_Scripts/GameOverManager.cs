using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text gameOverText;
    public TMP_Text highScoreText;

    void Start()
    {
        
        
        
        gameOverText.text = "Game Over";
        
        highScoreText.text = "High Score: " + UIManager.currentHighScore;
            

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

