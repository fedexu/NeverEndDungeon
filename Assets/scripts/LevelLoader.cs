using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public GameObject LoadingLayer;
    public GameObject toHide;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(loadAsynchronously(sceneIndex));
    }

    private IEnumerator loadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingLayer.SetActive(true);
        toHide.SetActive(false);
        while (!operation.isDone)
        {
            // do staff in the meantime that is loading
            yield return null;
        }
    }

}
