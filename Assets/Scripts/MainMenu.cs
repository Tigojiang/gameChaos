using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("MainMenuPop");
    }
    public void QuitGame(){
    	Application.Quit();
    	Debug.Log("quit");
    }
}