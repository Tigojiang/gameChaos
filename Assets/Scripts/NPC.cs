using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
public abstract class NPC : MonoBehaviour
{
	[SerializeField]
    protected float speed;
    protected bool canMove = true;
    protected Vector2 direction;
    protected Vector2[] options = {Vector2.up,Vector2.left,Vector2.down,Vector2.right};
    protected Animator animator;
    protected int time = 0;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
    public virtual void move()
    {
    }
    protected virtual void updateDirection(){

    }
    protected virtual void OnCollisionEnter2D(Collision2D other){

    }
    protected void OnCollisionExit2D(Collision2D other){
        canMove = true;
        time = 0;
        GameManager.triggerDialogue=false;
        GameManager.role=0;
    } 
}
