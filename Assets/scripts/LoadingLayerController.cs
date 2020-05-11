using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingLayerController : MonoBehaviour
{

    private CanvasGroup group;

    void Awake()
    {
        group = transform.gameObject.GetComponent<CanvasGroup>();
    }

    public void setLoadingLayer()
    {
        group.alpha = 1;
    }

    public void removeLoadingLayer()
    {
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        while (group.alpha > 0)
        {
            group.alpha -= 0.1f;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
