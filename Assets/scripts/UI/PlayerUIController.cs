using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject playButton;
    public GameObject backButton;
    public GameObject optionsButton;
    public GameObject DepthLevel;
    public GameObject HpBar;
    private GameController gameController;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void buttonClickedBehavior(string buttonText)
    {
        if (buttonText == "PLAY")
        {
            pauseMenu.SetActive(false);
            gameController.isPlaying = true;
        }
        if (buttonText == "PAUSE")
        {
            pauseMenu.SetActive(true);
            gameController.isPlaying = false;
        }
        if (buttonText == "BACK")
        {
            backToTitle();
        }
        if (buttonText == "OPTIONS")
        {
            
        }
    }

    public void backToTitle()
    {
        gameController.GetLevelLoader().LoadLevel("Menu");
        gameController.isPlaying = true;
    }

    private void Update() {
        DepthLevel.GetComponent<Text>().text = gameController.currentPlayerLevel.ToString();
        HpBar.GetComponent<Text>().text = gameController.hp.ToString();
    }

}
