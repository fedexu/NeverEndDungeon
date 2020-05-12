using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public static LevelLoader Instance { get; private set; }
    private CanvasGroup group;

    public bool loading = false;

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

    private void Start()
    {
        group = transform.gameObject.GetComponent<CanvasGroup>();
    }

    public void LoadLevel(string scene)
    {
        if (scene == "Menu")
        {
            StartCoroutine(waitingRoom(scene));
        }
        else
        {
            StartCoroutine(loadAsynchronously(scene));
        }

    }

    private IEnumerator loadAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        addLoadingLayer();
        while (!operation.isDone)
        {
            // do staff in the meantime that is loading
            yield return null;
        }
    }

    public float timer = 0.0f;
    private IEnumerator waitingRoom(string scene)
    {
        // turn seconds in float to int
        addLoadingLayer();
        while (timer < 2.0f)
        {
            // seconds in float
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0.0f;
        StartCoroutine(loadAsynchronously(scene));
    }

    public void addLoadingLayer()
    {
        transform.gameObject.GetComponent<Canvas>().sortingOrder = 10;
        group.alpha = 1;
        loading = true;
    }

    public void removeLoadingLayer(bool isFadeOut)
    {
        if (isFadeOut)
        {
            StartCoroutine(fadeOut());
        }
        else
        {
            transform.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            group.alpha = 0;
            loading = false;
        }
    }

    IEnumerator fadeOut()
    {
        while (group.alpha > 0)
        {
            group.alpha -= 0.1f;
            yield return null;
        }
        transform.gameObject.GetComponent<Canvas>().sortingOrder = -1;
        loading = false;
    }

    public bool isLoading(){
        return loading;
    }

}
