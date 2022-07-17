using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmashScript : MonoBehaviour, IPlayer
{
    [SerializeField] bool isOne;
    [SerializeField] int count = 0;
    [SerializeField] float roundTime = 4f;
    private bool canMove = false;
    private RefereeScript refereeScript;

    private void Awake() {
        refereeScript = FindObjectOfType<RefereeScript>();
    }

    public int GetCount(){
        return count;
    }
    
    public void CanStart(){
        canMove = true;
        StartCoroutine(StartTimer());
    }

    public void Finish(){
        if (isOne){ 
            refereeScript.P1HasFinished();
        }else{
            refereeScript.P2HasFinished();
        }
    }

    public void Lose(){
        return;
    }

    public bool IsOne(){
        return isOne;
    }

    IEnumerator StartTimer(){
        yield return new WaitForSeconds(roundTime);
        Finish();
    }
}
