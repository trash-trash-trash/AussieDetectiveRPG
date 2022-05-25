using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialogue }

public class GameController : MonoBehaviour
{

	[SerializeField] PlayerScript playerScript;
	[SerializeField] CharacterAnimator playerAnimator;


	GameState state;
      
    private void Awake()
    {
		// ConditionsDB.Init();
		state = GameState.FreeRoam;
	}
	
	private void Start()
	{
		DialogueManager.Instance.OnShowDialogue += () =>
		{
			state = GameState.Dialogue;
			playerAnimator.IsMoving=false;
		};
		DialogueManager.Instance.OnCloseDialogue += () =>
		{
			if (state == GameState.Dialogue)
			state = GameState.FreeRoam;
		};
	}

	private void Update()
    {
		if (state == GameState.FreeRoam)
		{
			playerScript.HandleUpdate();
		}
		else if (state == GameState.Dialogue)
		{
			DialogueManager.Instance.HandleUpdate();
		}
    }
	
	
}
