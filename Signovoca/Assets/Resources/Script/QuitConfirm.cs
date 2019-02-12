using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitConfirm : MonoBehaviour {

 
    public CanvasGroup Canvas01;
    public CanvasGroup Canvas02;

    // Use this for initialization
    private void Awake()
    {
        //disable the quit confirmation panel
        DoConfirmQuitNo();
    }

    /// Called if clicked on No (confirmation)
    public void DoConfirmQuitNo()
    {
        Debug.Log("Back to the game");

        //enable the normal panel_menu
        Canvas01.alpha = 1;
        Canvas01.interactable = true;
        Canvas01.blocksRaycasts = true;

        //disable the confirmation quit ui
        Canvas02.alpha = 0;
        Canvas02.interactable = false;
        Canvas02.blocksRaycasts = false;
    }

    
    /// Called if clicked on Yes (confirmation)
    public void DoConfirmQuitYes()
    {
        Debug.Log("You Quit");
        Application.Quit();
    }


    /// Called if clicked on Quit
    public void DoQuit()
    {
        Debug.Log("Check form quit confirmation");

        //reduce the visibility of panel_menu, and disable all interraction
        Canvas01.alpha = 0.5f;
        Canvas01.interactable = false;
        Canvas01.blocksRaycasts = false;

        //enable interraction with confirmation gui and make visible
        Canvas02.alpha = 1;
        Canvas02.interactable = true;
        Canvas02.blocksRaycasts = true;
    }

    
}
