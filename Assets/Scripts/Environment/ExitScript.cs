using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour, Interactable
{
    //this Script is used for allowing the Player to move between Scenes

    GetMyText setText;

	[SerializeField] string SceneName;

    GetMyText getText;

    public void Awake()
    {
        getText = GameObject.FindGameObjectWithTag("PersistentGameObject").GetComponentInChildren<GetMyText>();
    }

    public IEnumerator Interact(Transform initiator)
    {
        PlayerPrefs.SetString("LocationName", SceneName);
        getText.SetText();
        Loader.Load(SceneName);
        yield return null;
    }

}