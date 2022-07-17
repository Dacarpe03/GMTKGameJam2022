using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCliffScript : MonoBehaviour, IPlayer
{
    bool isRunning = true;
    bool stop = false;

    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float decceleration = 0.1f;

    Vector2 velocity = new Vector2(0, 0);
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }   

    private void Update() {
        if (isRunning){
            velocity.x += acceleration;
            rb.velocity = velocity;
        }else{
            velocity.x -= decceleration;
            rb.velocity = velocity;
            if (velocity.x <= 0){
                Finish();
                stop = true;
            }
        }

        if (stop){
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    public int GetCount(){
        return 0;
    }

    public void CanStart(){
        isRunning = true;
    }

    public void Finish(){

    }

    public void Lose(){

    }

    public bool IsOne(){
        return false;
    }

    public void OnP1Spam(){
        isRunning = false;
    }
}
