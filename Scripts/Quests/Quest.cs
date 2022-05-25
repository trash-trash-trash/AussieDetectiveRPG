using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestStatus {None, Started, Completed}

//public bool CanBeCompleted()
//
//
public class Quest
{
    public QuestBase Base { get; private set; }
    public QuestStatus Status { get; private set; }

    public Quest(QuestBase _base)
    {
        Base = _base;
    }

    public IEnumerator StartQuest()
    {
        Status = QuestStatus.Started;

       yield return DialogueManager.Instance.ShowDialogue(Base.StartDialogue);
    }

    public IEnumerator CompleteQuest()
    {
        Status = QuestStatus.Completed;

        yield return DialogueManager.Instance.ShowDialogue(Base.CompletedDialogue);

       // var inventory Inventory.GetInventory();
       // if (Base.RequiredItem != null)
       // {
      //      inventory.RemoveItem(Base.RequiredItem)
      //  }
    }
}