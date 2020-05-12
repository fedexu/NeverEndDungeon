using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject newGame;
    public GameObject character;
    public GameObject options;
    public GameObject credits;

    private GameController gameController;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        if (gameController.GetLevelLoader() != null)
        {
            if (gameController.GetLevelLoader().isLoading())
            {
                gameController.GetLevelLoader().removeLoadingLayer(true);
            }
        }
        showStartMenu();
    }

    public void quit()
    {
        Debug.Log("Exit application");
        Application.Quit();
    }

    public void buttonClickedBehavior(string buttonText)
    {
        if (buttonText == "PLAY")
        {
            playGame();
        }
        if (buttonText == "OPTIONS")
        {
            showOptions();
        }
        if (buttonText == "CHARACTER")
        {
            showCharacterOptions();
        }
        if (buttonText == "QUESTION")
        {
            showCredit();
        }

    }

    public void playGame()
    {
        gameController.GetLevelLoader().LoadLevel("Dungeon");
    }

    public void showStartMenu()
    {
        newGame.SetActive(true);
        character.SetActive(true);
        options.SetActive(true);
        credits.SetActive(true);
    }

    public void showOptions()
    {

    }

    public void showCharacterOptions()
    {

    }

    public void showCredit()
    {

    }

}
