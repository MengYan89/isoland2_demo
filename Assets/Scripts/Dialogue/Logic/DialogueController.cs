using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public Dialogue_Data_SO dialogueEmpty;

    public Dialogue_Data_SO dialogueFinish;

    private ConcurrentStack<string> dialogueEmptyStack;

    private ConcurrentStack<string> dialogueFinishStack;

    private bool isTalking;

    private void Awake()
    {
        FillDialogueStack();
    }


    private void FillDialogueStack()
    {
        dialogueEmptyStack = new ConcurrentStack<string>();
        dialogueFinishStack = new ConcurrentStack<string>();

        for (int i = dialogueEmpty.dialogueList.Count -  1; i > -1; i--)
        {
            dialogueEmptyStack.Push(dialogueEmpty.dialogueList[i]);
        }

        for (int i = dialogueFinish.dialogueList.Count - 1; i > -1; i--)
        {
            dialogueFinishStack.Push(dialogueFinish.dialogueList[i]);
        }

    }

    public void ShowDialogueEmpty()
    {
        if (!isTalking)
        {
            StartCoroutine(DialogueRoutine(dialogueEmptyStack));
        }
    }

    public void ShowDialogueFinish()
    {
        if (!isTalking)
        {
            StartCoroutine(DialogueRoutine(dialogueFinishStack));
        }
    }

    private IEnumerator DialogueRoutine(ConcurrentStack<string> data)
    {
        isTalking = true;

        if (data.TryPop(out string result))
        {
            EventHandler.CallShowDialogueEvent(result);
            yield return null;
            isTalking = false;
            EventHandler.CallGameStateChangeEvent(GameState.Pause);
        }
        else
        {
            EventHandler.CallShowDialogueEvent(string.Empty);
            // TODO 有溢出问题
            FillDialogueStack();
            isTalking = false;
            EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
        }
    }

}
