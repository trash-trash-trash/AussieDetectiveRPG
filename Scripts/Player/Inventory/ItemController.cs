using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour, Interactable
{
    [SerializeField] Dialogue dialogue;
    public IEnumerator Interact(Transform initiator)
    {
        yield return DialogueManager.Instance.ShowDialogue(dialogue);
    }
}

