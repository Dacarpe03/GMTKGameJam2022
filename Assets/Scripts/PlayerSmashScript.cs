using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmashScript : MonoBehaviour, IPlayer
{
    [SerializeField] bool isOne;
    [SerializeField] int count = 0;
    private bool canStart = false;
    private RefereeScript refereeScript;

    private void Awake() {
        refereeScript = FindObjectOfType<RefereeScript>();
    }

    void Update()
    {
        if (canStart){
            Finish();
        }
    }

    public int GetCount(){
        return count;
    }
    
    public void CanStart(){
        canStart = true;
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
}
