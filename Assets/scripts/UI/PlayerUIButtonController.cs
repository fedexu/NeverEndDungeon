using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIButtonController : BasicButton
{
    private PlayerUIController playerUIController;

    void Awake()
    {
        playerUIController = FindObjectOfType<PlayerUIController>();
    }

    public override void doAfterClickEvent(string message, string text)
    {
        playerUIController.buttonClickedBehavior(text);
    }


}
