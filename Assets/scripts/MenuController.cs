using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject LevelLoader;
    public GameObject newGame;
    public GameObject character;
    public GameObject options;
    public GameObject credits;

    public void playGame(){
        LevelLoader.GetComponent<LevelLoader>().LoadLevel(1);
    }
    
    private void Start() {
        showStartMenu();
    }

    public void quit(){
        Debug.Log("Exit application");
        Application.Quit();
    }

    public void buttonClickedBehavior(string buttonText){
        if (buttonText == "NEW GAME"){
            playGame();
        }
        if (buttonText == "OPTIONS"){
            showOptions();
        }

    }

    public void showStartMenu(){
        newGame.SetActive(true);
        character.SetActive(true);
        options.SetActive(true);
        credits.SetActive(true);
        
    }

    public void showOptions(){

    }


}
