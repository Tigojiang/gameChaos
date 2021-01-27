using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;
public class VenderMachine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Player" && !GameManager.justBuy){
            GameManager.justBuy = true;
        	SceneManager.LoadScene("shopping");
        }
    }
    private void OnCollisionExit2D(Collision2D other){
        GameManager.justBuy = false;
    }
}
