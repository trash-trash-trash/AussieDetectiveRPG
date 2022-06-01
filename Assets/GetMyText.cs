using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetMyText : MonoBehaviour
{
    //this script displays the current location each time the Player changes scenes
    //waits a short time and fades out

    //declares text
    private TMP_Text myText;

    //declares location name
    string LocationName;

    public static GetMyText getText;

    private void Start()
    {
        myText = this.GetComponent<TMP_Text>();

        myText.enabled = true;

    }

    public void SetText()
    {
        LocationName = PlayerPrefs.GetString("LocationName");
        myText.text = LocationName;

        if (LocationName != "Main Menu")
        {
            StartCoroutine(FadeText());
        }

        IEnumerator FadeText()
        {
            myText.enabled = true;

            yield return new WaitForSeconds(2);

            myText.enabled = false;

        }
    }
}
