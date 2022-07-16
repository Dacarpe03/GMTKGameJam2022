using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("Adding points to P2");
        P2Score += score;
        if (P2Score > 7){
            Debug.Log("Two wins");
        }else{
            StartCoroutine(NextGame());
        }
    }

    public void AddP1Score(int score){
        Debug.Log("Adding points to P2");
        P1Score += score;
        if (P1Score > 7){
            Debug.Log("One wins");
        }else{
            StartCoroutine(NextGame());
        }
    }

    public IEnumerator NextGame(){
        yield return new WaitForSeconds(1.5f);
        int nextSceen = Random.Range(2, 4);
        SceneManager.LoadScene(nextSceen);
    }
}
