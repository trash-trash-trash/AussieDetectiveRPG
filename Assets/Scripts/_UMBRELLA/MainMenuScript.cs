using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    //Script for the Main Menu

    //currently contains:
    //
    //setting PlayerName logic
    //
    //Start Button that transitions to OfficeScene

    //Player name input
    private string input;

    //declares GetMyText
    GetMyText getText;

    private void Awake()
    {
        //GetMyText is in the PersistentGameObject
        getText = GameObject.FindGameObjectWithTag("PersistentGameObject").GetComponentInChildren<GetMyText>();

        //sets location name as main menu
        PlayerPrefs.SetString("LocationName", "Main Menu");
        getText.SetText();
    }

    //uses the canvas tmpro input object
    public void ReadStringInput(string s)
    {
        input=s;
        Debug.Log(input);
        PlayerPrefs.SetString("PlayerName", s);
    }

    //clickable start game button
    //sets the location as Player's Office 
    //tells GetMyText location name
    //loads
    public void StartGame()
    {
        string PlayerName = PlayerPrefs.GetString("PlayerName");
        PlayerPrefs.SetString("LocationName", PlayerName + "'s Office");
        getText.SetText();
        Loader.Load("OfficeScene");
    }

}
