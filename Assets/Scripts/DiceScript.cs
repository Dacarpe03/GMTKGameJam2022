using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiceScript : MonoBehaviour
{
    private RefereeScript refereeScript;
    private SpriteRenderer myRenderer;
    [SerializeField] List<Sprite> diceFaces;
    [SerializeField] float swapTime = 3f;
    private void Awake() {
        refereeScript = FindObjectOfType<RefereeScript>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        StartCoroutine(Roll());
    }

    IEnumerator Roll(){
        List<int> faceList = new List<int>() { 1, 2, 3, 4, 5, 6};
        for (int i = 0; i < faceList.Count; i++) {
            int temp = faceList[i];
            int randomIndex = Random.Range(i, faceList.Count);
            faceList[i] = faceList[randomIndex];
            faceList[randomIndex] = temp;
        }

        int faceIndex = 0;
        bool white = false;
        while (faceIndex < faceList.Count){
            if (white){
                myRenderer.sprite = diceFaces[0];
            }else{
                myRenderer.sprite = diceFaces[faceIndex];
                faceIndex ++;
            }
            yield return new WaitForSeconds(swapTime);
        }
        refereeScript.SetRoundPoints(faceList[5]);
        Destroy(this.gameObject);
    }
}
