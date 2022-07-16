using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RefereeScript : MonoBehaviour
{
    private ScoreKeeperScript scoreKeeperScript;
    
    private bool P1Ready = false;
    private bool P2Ready = false;
    private bool diceSpawned = false;
    [SerializeField] GameObject dice;
    
    private bool P1Finished;
    private bool P2Finished;

    private void Awake() {
        scoreKeeperScript = FindObjectOfType<ScoreKeeperScript>();    
    }

    private void Update() {
        SpawnDice();
    }

    void OnP1Action(InputValue value){
        P1Ready = value.isPressed;
    }

    void OnP2Action(InputValue value){
        P2Ready = value.isPressed;
    }

    void SpawnDice(){
        if (P1Ready && P2Ready && !diceSpawned){
            Debug.Log("SpawningDice");
            Instantiate(dice, transform.position, Quaternion.identity);
            diceSpawned = true;
        }
    }

}
