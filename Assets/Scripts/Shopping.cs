using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Shopping : MonoBehaviour
{
	void Start(){
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
	}
    public void exit(){
    	 SceneManager.LoadScene("Game");
    }
}
