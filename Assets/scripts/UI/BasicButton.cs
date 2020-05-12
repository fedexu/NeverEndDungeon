using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BasicButton : MonoBehaviour
{
    public Animator animator;
    public string text;

    void Start()
    {
        transform.Find("Text").gameObject.GetComponent<Text>().text = text;
    }

    public void clickButton()
    {
        animator.SetBool("isClicked", true);
    }
    public void clickButtonNoAnim()
    {
        doAfterClickEvent("", text);
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("clickButtonEnd"))
        {
            animator.SetBool("isClicked", false);
            doAfterClickEvent(message, text);
        }
    }

    public abstract void doAfterClickEvent(string message, string text);

}