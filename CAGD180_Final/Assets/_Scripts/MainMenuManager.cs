using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class MainMenuManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
