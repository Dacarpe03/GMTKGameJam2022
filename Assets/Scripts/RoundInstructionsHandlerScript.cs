using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class RoundInstructionsHandlerScript : MonoBehaviour
{
    private bool P1Ready = false;
    private bool P2Ready = false;

    [SerializeField] TextMeshProUGUI p1ReadyText;
    [SerializeField] TextMeshProUGUI p2ReadyText;
    [SerializeField] List<GameObject> destroyTexts;

    void Update(){
        if (P1Ready){
            p1ReadyText.text = "P1 Ready";
        }else{
            p1ReadyText.text = "";
        }
  
        if (P2Ready){
            p2ReadyText.text = "P2 Ready";
        }else{
            p2ReadyText.text = "";
        }

        if (P2Ready && P1Ready){
            DestroyTexts();
        }
    }

    void OnP1Action(InputValue value){
        P1Ready = value.isPressed;
        Debug.Log("Aqui");
    }

    void OnP2Action(InputValue value){
        P2Ready = value.isPressed;
    }

    void DestroyTexts(){
        foreach(GameObject g in destroyTexts){
            Destroy(g);
        }
        Destroy(this);
    }
}