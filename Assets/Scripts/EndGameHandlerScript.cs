using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameHandlerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI P1Score;
    [SerializeField] TextMeshProUGUI P2Score;
    ScoreKeeperScript score;

    private void Awake() {
        score = FindObjectOfType<ScoreKeeperScript>();
    }

    private void Start(){
        P1Score.text = score.GetP1Score().ToString() + "/7";
        P2Score.text = score.GetP2Score().ToString() + "/7";
        if (score.GetP1Score() >= 7){
            resultText.text = "Player 1 wins";
        }else{
            resultText.text = "Player 2 wins";
        }
    }

}
