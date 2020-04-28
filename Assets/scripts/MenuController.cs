using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject LevelLoader;
    public GameObject playBtton;
    public GameObject playLevel1Btton;
    public GameObject playLevel2Btton;
    public GameObject playLevel3Btton;

    public void onClickPlay(){
        playBtton.SetActive(false);
        playLevel1Btton.SetActive(true);
        playLevel2Btton.SetActive(true);
        playLevel3Btton.SetActive(true);
    }

    public void playGame(int level){
        GameController.Instance.currentPlayerLevel = level;
        LevelLoader.GetComponent<LevelLoader>().LoadLevel(1);
    }
    
    private void Start() {
        playBtton.SetActive(true);
        playLevel1Btton.SetActive(false);
        playLevel2Btton.SetActive(false);
        playLevel3Btton.SetActive(false);
    }


}
