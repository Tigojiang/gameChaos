using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;
using static GameManager;

public class OldMan : NPC
{
    protected override void Start(){
        animator = GetComponent<Animator>();
        transform.position=GameManager.oldManPosition;
    }
	protected override void Update(){
		if(time==250 && canMove && !GameManager.triggerDialogue){
            updateDirection();
        }
        if(time>250 && canMove && !GameManager.triggerDialogue){
            move();
        }
        time++;
        if(time>500){
            time=0;
            animator.SetBool("oldManIdle",true);
            animator.SetBool("oldManWalk",false);
        }
	}
    public override void move(){
        // transform.Translate(direction*speed*Time.deltaTime);
        transform.Translate(direction*speed*Time.deltaTime);
        GameManager.oldManPosition = transform.position;
    }
	protected override void updateDirection(){
        Random rnd = new Random();
        int num = rnd.Next(4);
        direction = options[num];
        animator.SetBool("oldManIdle",false);
        animator.SetBool("oldManWalk",true);
    }

    protected override void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Player" && !GameManager.triggerDialogue){
            canMove = false;
            animator.SetBool("oldManIdle",true);
            animator.SetBool("oldManWalk",false);
            SceneManager.LoadScene("GamePop");
            GameManager.triggerDialogue = true;
            GameManager.role = 2;
        }
    }

}
