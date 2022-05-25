using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour, Interactable
{
	//this Script is used for allowing the Player to move between Scenes

	[SerializeField] string SceneName;public IEnumerator Interact(Transform initiator)
    {
        Loader.Load(SceneName);
        yield return null;
    }

}