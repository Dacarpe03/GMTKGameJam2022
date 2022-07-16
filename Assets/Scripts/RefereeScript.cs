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
    private int roundPoints;
    [SerializeField] GameObject dice;
    
    private bool P1Finished;
    private bool P2Finished;

    private void Awake() {
        scoreKeeperScript = FindObjectOfType<ScoreKeeperScript>();    
    }

    private void Update() {
        if (P1Ready && P2Ready){
            RollDice();
        }

        if (P1Finished && P2Finished){
            CountResults();
        }
    }

    void OnP1Action(InputValue value){
        P1Ready = value.isPressed;
    }

    void OnP2Action(InputValue value){
        P2Ready = value.isPressed;
    }

    void RollDice(){
        if (P1Ready && P2Ready && !diceSpawned){
            Debug.Log("SpawningDice");
            Instantiate(dice, transform.position, Quaternion.identity);
            diceSpawned = true;
        }
    }

    void P1HasFinished(){
        P1Finished = true;
    }

    void P2HasFinished(){
        P2Finished = true;
    }

    public void SetRoundPoints(int points){
        roundPoints = points;
    }
    void CountResults(){
        //float P1Count = player1.GetCount();
        //float P2Count = player2.GetCount();
        //if (P1Count > P2Count){
        //    scoreKeeperScript.AddP1Score(roundPoints);
        //}else if (P2Count > P1Count){
        //    scoreKeeperScript.AddP2Score(roundPoints);
        //}else{
        //    scoreKeeperScript.NextGame();
        //}
    }

}
