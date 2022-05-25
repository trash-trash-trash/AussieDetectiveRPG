using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{

    [SerializeField] string myName;
    [SerializeField] Dialogue dialogue;
    [SerializeField] QuestBase questToStart;
    [SerializeField] List<Vector2> movementPattern;
    [SerializeField] float timeBetweenPattern;

	NPCState state;
	float idleTimer = 0f;
    int currentPattern = 0;
    Quest activeQuest;

	Character character;

    private void Awake()
    {
		character = GetComponent<Character>();
    }

    public IEnumerator Interact(Transform initiator)
	{
        state = NPCState.Dialogue;
        character.LookTowards(initiator.position);

      //  if (questToStart != null)
      //  {
      //      activeQuest = new Quest(questToStart);
      //      yield return activeQuest.StartQuest();
      //      questToStart = null;
      //  }
      //  else if (activeQuest != null)
       // {
        //    if(activeQuest.CanBeCompleted())
        //    {
        //        yield return activeQuest.CompleteQuest(initiator);
         //       activeQuest = null;
         //   }
         //   else
        //    {
            //    yield return DialogueManager.Instance.ShowDialogue(activeQuest.Quest.InProgressDialogue);
           // }
      //  }
       // else
      //  {
            yield return DialogueManager.Instance.ShowDialogue(dialogue);
      //  }
	}

    private void Update()
    {
        if (DialogueManager.Instance.IsShowing) return;

		if(state == NPCState.Idle)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer > timeBetweenPattern)
            {
                idleTimer = 0f;
                if (movementPattern.Count > 0)
                    StartCoroutine(Walk());
            }
        }

        character.HandleUpdate();
    }

    IEnumerator Walk()
    {
        state = NPCState.Walking;

        var oldPos = transform.position;

        yield return character.Move(movementPattern[currentPattern]);

        if(transform.position != oldPos)
             currentPattern = (currentPattern + 1) % movementPattern.Count;

        state = NPCState.Idle;
    }

}

public enum NPCState {  Idle, Walking, Dialogue }
