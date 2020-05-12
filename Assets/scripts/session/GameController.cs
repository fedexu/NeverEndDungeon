using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController Instance { get; private set; }

    public int currentPlayerLevel;
    public int hp;

    public bool isPlaying = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() {
        LoadLoadingScene();
        currentPlayerLevel = 1;
        hp = 10;
    }

    private void LoadLoadingScene(){
         SceneManager.LoadScene("LoadingScene", LoadSceneMode.Additive);
    }


    public LevelLoader GetLevelLoader(){
        return FindObjectOfType<LevelLoader>();
    }

}