using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
public class Player : MonoBehaviour
{
    [SerializeField]
	private float speed;
    private int curDirection;
    private bool[] ifMove = {true,true,true,true};
    // 0 1 2 3 = > top bot left right
	private Vector2 direction;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = GameManager.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        move();
    }
    public void move()
    {
    	// transform.Translate(direction*speed*Time.deltaTime);
        transform.Translate(direction*speed*Time.deltaTime);
        GameManager.position = transform.position;
    }
    private void GetInput(){
    	direction = Vector2.zero;
    	if(Input.GetKey(KeyCode.W) && ifMove[0]){
    		direction+=Vector2.up;
            animator.SetBool("playerWalk",true);
            animator.SetBool("playerIdle",false);
            curDirection=0;
    	}else if(Input.GetKey(KeyCode.S) && ifMove[1]){
    		direction+=Vector2.down;
            animator.SetBool("playerWalk",true);
            animator.SetBool("playerIdle",false);
            curDirection=1;
    	}else if(Input.GetKey(KeyCode.A) && ifMove[2]){
    		direction+=Vector2.left;
            animator.SetBool("playerWalk",true);
            animator.SetBool("playerIdle",false);
            curDirection=2;
    	}else if(Input.GetKey(KeyCode.D) && ifMove[3]){
    		direction+=Vector2.right;
            animator.SetBool("playerWalk",true);
            animator.SetBool("playerIdle",false);
            curDirection=3;
    	}else{
            animator.SetBool("playerWalk",false);
            animator.SetBool("playerIdle",true);
        }
    }
    private void OnCollisionEnter2D(Collision2D other){
        ifMove[curDirection] = false;
    }
    private void OnCollisionExit2D(Collision2D other){
        for(int i=0;i<4;i++){
            ifMove[i]=true;
        }
        
    } 

}
