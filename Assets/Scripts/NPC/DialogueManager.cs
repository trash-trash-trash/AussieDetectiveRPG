using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	[SerializeField] GameObject dialogueCanvas = null;
	[SerializeField] Text dialogueText = null;
	[SerializeField] int lettersPerSecond = 0;

	//prevent NPC's from moving while dialogue is active
	public bool IsShowing { get; private set; }
	
	public event System.Action OnShowDialogue;
	public event System.Action OnCloseDialogue;
	
	public static DialogueManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}
	
	public IEnumerator ShowDialogue(Dialogue dialogue)
	{
		yield return new WaitForEndOfFrame();
		
		OnShowDialogue?.Invoke();
		IsShowing = true;
		dialogueCanvas.SetActive(true);

		foreach (var line in dialogue.Lines)
        {
			yield return TypeDialogue(line);
			yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }
	
		dialogueCanvas.SetActive(false);
		IsShowing = false;
		OnCloseDialogue?.Invoke();
	}
	
	public void HandleUpdate()
	{
		
	}

	public IEnumerator TypeDialogue(string line)
	{
		dialogueText.text = "";
		foreach (var letter in line.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(1f / lettersPerSecond);
		}
	}

}