using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    public Animator animator;
    public string text;

    public MenuController menuController;

    void Start(){
        transform.Find("Text").gameObject.GetComponent<Text>().text = text;
    }
    public void clickButton(){
        animator.SetBool("isClicked", true);
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("clickButtonEnd"))
        {
            animator.SetBool("isClicked", false);
            menuController.buttonClickedBehavior(text);
        }
    }

}
