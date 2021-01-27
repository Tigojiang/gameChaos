using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPopEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame(){
    	SceneManager.LoadScene("UI");
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
