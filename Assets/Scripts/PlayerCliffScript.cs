using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCliffScript : MonoBehaviour, IPlayer
{
    [SerializeField] bool isOne;
    bool isRunning = true;
    bool canMove = false;
    bool stop = false;

    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float decceleration = 0.1f;

    Vector2 velocity = new Vector2(0.1f, 0f);
    Rigidbody2D rb;

    private RefereeScript refereeScript;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        refereeScript = FindObjectOfType<RefereeScript>();
    }   

    private void Update() {
        if (canMove){
            if (isRunning){
                if (isOne){ 
                    velocity.x += acceleration;
                    rb.velocity = velocity;
                }else{
                    velocity.x -= acceleration;
                }
                rb.velocity = velocity;
            }else{
                if (isOne){ 
                    velocity.x -= decceleration;
                }else{
                    velocity.x += decceleration;
                }
                rb.velocity = velocity;
                if (velocity.x < 0 && isOne){
                    Finish();
                    stop = true;
                } else if (velocity.x > 0 && !isOne){
                    Finish();
                    stop = true;
                }
            }

            if (stop){
                rb.velocity = new Vector2(0f, 0f);
            }
        }
    }

    public int GetCount(){
        float fcount = Mathf.Abs(Vector2.Distance(this.transform.position, new Vector2(0f, 0f)));
        int count = (int)fcount * -100;
        return count;
    }

    public void CanStart(){
        canMove = true;
    }

    public void Finish(){
        if (isOne){ 
            refereeScript.P1HasFinished();
        }else{
            refereeScript.P2HasFinished();
        }
    }


    public void Lose(){

    }

    public bool IsOne(){
        return isOne;
    }

    public void OnP1Spam(){
        if(isOne && canMove){
            isRunning = false;
        }
    }

    public void OnP2Spam(){
        if(!isOne && canMove){
            isRunning = false;
        }
    }
}
