using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.SceneManagement;
using static GameManager;
public class Robot : NPC
{
    protected override void Start(){
        animator = GetComponent<Animator>();
        transform.position=GameManager.robotPosition;
    }

	protected override void Update(){
		if(time==250 && canMove && !GameManager.triggerDialogue){
            updateDirection();
        }
        if(time>250 && canMove && !GameManager.triggerDialogue){
            move();
        }
        time++;
        if(time>600){
            time=0;
            animator.SetBool("robotIdle",true);
            animator.SetBool("robotRun",false);
        }
        if(GameManager.state==7){
            animator.SetBool("robotIdle",false);
            animator.SetBool("robotRun",false);
            animator.SetBool("robotDie",true);
        }
	}
    public override void move(){
        // transform.Translate(direction*speed*Time.deltaTime);
        transform.Translate(direction*speed*Time.deltaTime);
        GameManager.robotPosition = transform.position;
    }
	protected override void updateDirection(){
        Random rnd = new Random();
        int num = rnd.Next(4);
        direction = options[num];
        animator.SetBool("robotIdle",false);
        animator.SetBool("robotRun",true);
    }

    protected override void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Player" && !GameManager.triggerDialogue){
            canMove = false;
            animator.SetBool("robotIdle",true);
            animator.SetBool("robotRun",false);
            SceneManager.LoadScene("GamePop");
            GameManager.triggerDialogue = true;
            GameManager.role=3;
        }
        
    }
}
