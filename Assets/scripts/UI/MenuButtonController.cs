using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : BasicButton
{
   
    private MenuController menuController;

    void Awake() {
        menuController = FindObjectOfType<MenuController>();
    }

     public override void doAfterClickEvent(string message, string text)
    {
         menuController.buttonClickedBehavior(text);
    }

}
