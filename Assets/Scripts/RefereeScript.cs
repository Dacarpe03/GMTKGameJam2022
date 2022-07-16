using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;

public class RefereeScript : MonoBehaviour
{
    private IPlayer playerOne;
    private  IPlayer playerTwo;

    private ScoreKeeperScript scoreKeeperScript;
    private bool P1Ready = false;
    private bool P2Ready = false;
    private bool diceSpawned = false;
    private int roundPoints;
    [SerializeField] GameObject dice;
    [SerializeField] TextMeshProUGUI roundPointsText;
    private bool P1Finished;
    private bool P2Finished;
    private bool resultsCounted = false;

    private void Awake() {
        scoreKeeperScript = FindObjectOfType<ScoreKeeperScript>();
        IEnumerable<IPlayer> players = FindObjectsOfType<MonoBehaviour>().OfType<IPlayer>();
        foreach(IPlayer p in players){
            if (p.IsOne()){
                playerOne = p;
            }else{
                playerTwo = p;
            }
        }
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

    public void P1HasFinished(){
        P1Finished = true;
    }

    public void P2HasFinished(){
        P2Finished = true;
    }

    public void SetRoundPoints(int points){
        roundPoints = points;
        roundPointsText.text = "Winner gets " + roundPoints.ToString() + " points";
        Debug.Log("Round points: " + roundPoints.ToString());
    }

    void CountResults(){
        if (!resultsCounted){
            int P1Count = playerOne.GetCount();
            int P2Count = playerTwo.GetCount();
            if (P1Count > P2Count){
                scoreKeeperScript.AddP1Score(roundPoints);
                roundPointsText.text = "Player 1 wins    " + roundPoints.ToString() + " points";
            }else if (P2Count > P1Count){
                scoreKeeperScript.AddP2Score(roundPoints);
                roundPointsText.text = "Player 2 wins " + roundPoints.ToString() + " points";
            }else{
                roundPointsText.text = "Tie";
                StartCoroutine(scoreKeeperScript.NextGame());
            }
            resultsCounted = true;
        }
    }

}
