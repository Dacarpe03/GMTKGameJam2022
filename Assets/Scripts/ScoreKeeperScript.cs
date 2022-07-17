using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeperScript : MonoBehaviour
{
    [SerializeField] int P1Score;
    [SerializeField] int P2Score;
    private List<int> played = new List<int>();

    private void Awake() {
        ManageSingleton();
    }

    private void Start(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        played.Add(currentScene);
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
        if (P2Score >= 7){
            Debug.Log("Two wins");
            EndGame();
        }else{
            StartCoroutine(NextGame());
        }
    }

    public void AddP1Score(int score){
        Debug.Log("Adding points to P2");
        P1Score += score;
        if (P1Score >= 7){
            Debug.Log("One wins");
            EndGame();
        }else{
            StartCoroutine(NextGame());
        }
    }

    public void Tie(){
        StartCoroutine(NextGame());
    }

    public IEnumerator NextGame(){
        yield return new WaitForSeconds(1.5f);
        if (played.Count >= 2){
            played.Clear();
        }
        int nextSceen = 0;
        do{
            nextSceen = Random.Range(2, 4);
        }while(played.Contains(nextSceen));

        played.Add(nextSceen);
        
        SceneManager.LoadScene(nextSceen);
    }

    public void EndGame(){
        SceneManager.LoadScene(4);
    }
}
