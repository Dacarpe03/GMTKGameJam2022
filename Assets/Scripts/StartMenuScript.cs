using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public void LoadGame(){
        LoadScene(2);
    }

    public void LoadInstructions(){
        LoadScene(1);
    }

    public void Quit(){
        Application.Quit();
    }

    private void LoadScene(int index){
        SceneManager.LoadScene(index);
    }
}
