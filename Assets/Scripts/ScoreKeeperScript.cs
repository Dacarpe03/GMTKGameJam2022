using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeperScript : MonoBehaviour
{
    [SerializeField] int P1Score;
    [SerializeField] int P2Score;

    private void Awake() {
        ManageSingleton();
    }

    void ManageSingleton(){
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetP1Score(){
        return P1Score;
    }

    public int GetP2Score(){
        return P2Score;
    }

    public void AddP2Score(int score){
        P2Score += score;
        if (P2Score > 7){
            Debug.Log("Two wins");
        }
    }

    public void AddP1Score(int score){
        P1Score += score;
        if (P1Score > 7){
            Debug.Log("One wins");
        }
    }
}
